using MatchDataManager.Api.DTO.Teams.Commands;
using MatchDataManager.Api.Exceptions;
using MatchDataManager.Api.Infrastructure.Handlers.Teams;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Tests.Teams.Commands
{
    public class AddTeamCommandTest
    {
        private readonly Mock<ITeamsRepository> _teamsRepository;
        public AddTeamCommandTest()
        {
            _teamsRepository = new Mock<ITeamsRepository>();
        }
        private void SetContext(Team team)
        {
            _teamsRepository.Setup(x => x.AddTeam(It.IsAny<Team>())).ReturnsAsync(team);
        }

        [Fact]
        public void AddTeam_ShouldSucceded()
        {
            var team = new Team { Id = Guid.NewGuid(), CoachName = "coach name test", Name = "test name" };
            SetContext(team);
            var handler = new AddTeamCommandHandler(_teamsRepository.Object);
            var request = new AddTeamCommand { Team = team };

            var result = handler.Handle(request, CancellationToken.None);

            _teamsRepository.Verify(x => x.AddTeam(It.IsAny<Team>()), Times.Once);
            Assert.IsType<Team>(result.Result);
            Assert.Equal("test name", result.Result.Name);
            Assert.Equal("coach name test", result.Result.CoachName);
        }

        [Fact]
        public void AddTeam_ShouldThrowNameExistException()
        {
            var team = new Team { Id = Guid.NewGuid(), CoachName = "coach name test", Name = "test name" };
            SetContext(team);
            var handler = new AddTeamCommandHandler(_teamsRepository.Object);
            var request = new AddTeamCommand { Team = team };

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
            var team = new Team{ Id = id, CoachName = coach, Name = name };

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
        public void AddTeam_ShouldReturnInformationAboutTooLongCoachName(Guid id, string coach, string name)
        {
            var validator = new TeamValidator();
            var team = new Team { Id = id, CoachName = coach, Name = name };

            var result = validator.Validate(team);

            result.Equals("Length can't be longer than 55 signs.");
        }
    }
}
