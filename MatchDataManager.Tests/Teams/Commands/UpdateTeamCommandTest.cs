using MatchDataManager.Api.DTO.Teams.Commands;
using MatchDataManager.Api.Exceptions;
using MatchDataManager.Api.Infrastructure.Exceptions;
using MatchDataManager.Api.Infrastructure.Handlers.Teams;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Tests.Teams.Commands
{
    public class UpdateTeamCommandTest
    {
        private readonly Mock<ITeamsRepository> _teamsRepository;
        public UpdateTeamCommandTest()
        {
            _teamsRepository = new Mock<ITeamsRepository>();
        }
        private void SetContext(Team team)
        {
            _teamsRepository.Setup(x => x.UpdateTeam(It.IsAny<Team>())).ReturnsAsync(team);
        }

        [Fact]
        public void UpdateTeam_ShouldThrowNotFoundException()
        {
            var team = new Team { Id = Guid.NewGuid(), CoachName = "coach name test", Name = "test name" };
            SetContext(team);
            var handler = new UpdateTeamCommandHandler(_teamsRepository.Object);
            var request = new UpdateTeamCommand { Team = team };

            var result = handler.Handle(request, CancellationToken.None);

            Assert.ThrowsAsync<NotFoundException>(() => result);
        }

        [Fact]
        public void UpdateTeam_ShouldThrowNameExistException()
        {
            var team = new Team { Id = Guid.NewGuid(), CoachName = "coach name test", Name = "test name" };
            SetContext(team);
            var handler = new UpdateTeamCommandHandler(_teamsRepository.Object);
            var request = new UpdateTeamCommand { Team = team };

            var result = handler.Handle(request, CancellationToken.None);

            Assert.ThrowsAsync<NameExistException>(() => result);
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "", "name1")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", " ", "name1")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", null, "name1")]
        public void AddTeam_ShouldReturnInformationAboutCoachNameRequiredField(Guid id, string coach, string name)
        {
            var validator = new TeamValidator();
            var team = new Team { Id = id, CoachName = coach, Name = name };

            var result = validator.Validate(team);

            result.Equals("Coach name is required.");
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "coach name test1", "")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "coach name test1", " ")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "coach name test1", null)]
        public void AddTeam_ShouldReturnInformationAboutNameRequiredField(Guid id, string coach, string name)
        {
            var validator = new TeamValidator();
            var team = new Team { Id = id, CoachName = coach, Name = name };

            var result = validator.Validate(team);

            result.Equals("Name is required.");
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "coach name test1", "testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest")]
        public void AddTeam_ShouldReturnInformationAboutTooLongName(Guid id, string coach, string name)
        {
            var validator = new TeamValidator();
            var team = new Team { Id = id, CoachName = coach, Name = name };

            var result = validator.Validate(team);

            result.Equals("Length can't be longer than 255 signs.");
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest", "test name")]
        public void AddTeam_ShouldReturnInformationAboutTooLongCity(Guid id, string coach, string name)
        {
            var validator = new TeamValidator();
            var team = new Team { Id = id, CoachName = coach, Name = name };

            var result = validator.Validate(team);

            result.Equals("Length can't be longer than 55 signs.");
        }
    }
}
