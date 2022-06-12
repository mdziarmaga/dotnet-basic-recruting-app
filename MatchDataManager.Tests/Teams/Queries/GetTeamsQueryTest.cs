using MatchDataManager.Api.DTO.Teams.Queries;
using MatchDataManager.Api.Infrastructure.Handlers.Teams;
using MatchDataManager.Api.Repositories;
using MatchDataManager.Tests.Teams.Helpers;

namespace MatchDataManager.Tests.Teams.Queries
{
    public class GetTeamsQueryTest
    {
        private readonly Mock<ITeamsRepository> _teamsRepository;
        public GetTeamsQueryTest()
        {
            _teamsRepository = new Mock<ITeamsRepository>();
        }
        private void SetContext()
        {
            _teamsRepository.Setup(x => x.GetAllTeams()).ReturnsAsync(TeamsHelper.Get());
        }

        [Fact]
        public void GetLocations_ShouldReturnProperValues()
        {
            SetContext();
            var handler = new GetTeamsQueryHandler(_teamsRepository.Object);
            var request = new GetTeamsQuery();

            var result = handler.Handle(request, CancellationToken.None);

            result.Result.Should().NotBeNull();
            Assert.Equal(2, result.Result.Count());
        }
    }
}
