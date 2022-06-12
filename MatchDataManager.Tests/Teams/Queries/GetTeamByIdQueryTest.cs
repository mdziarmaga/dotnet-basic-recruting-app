using MatchDataManager.Api.DTO.Teams.Queries;
using MatchDataManager.Api.Infrastructure.Handlers.Teams;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using MatchDataManager.Tests.Teams.Helpers;

namespace MatchDataManager.Tests.Teams.Queries
{
    public class GetTeamByIdQueryTest
    {
        private readonly Mock<ITeamsRepository> _teamsRepository;
        public GetTeamByIdQueryTest()
        {
            _teamsRepository = new Mock<ITeamsRepository>();
        }
        private void SetContext()
        {
            _teamsRepository.Setup(x => x.GetTeamById(It.IsAny<Guid>())).ReturnsAsync(TeamsHelper.Get().FirstOrDefault);
        }

        [Fact]
        public void GetLocationById_ShouldReturnLocation()
        {
            SetContext();
            var id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var handler = new GetTeamByIdQueryHandler(_teamsRepository.Object);
            var request = new GetTeamByIdQuery { Id = id };

            var result = handler.Handle(request, CancellationToken.None);

            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType<Team>();
            Assert.Equal("test name1", result.Result.Name);
            Assert.Equal("coach name test1", result.Result.CoachName);
        }
    }
}
