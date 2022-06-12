using MatchDataManager.Api.DTO.Teams.Commands;
using MatchDataManager.Api.Infrastructure.Handlers.Teams;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Tests.Teams.Commands
{
    public class DeleteTeamCommandTest
    {
        private readonly Mock<ITeamsRepository> _teamsRepository;
        public DeleteTeamCommandTest()
        {
            _teamsRepository = new Mock<ITeamsRepository>();
        }
        private void SetContext()
        {
            _teamsRepository.Setup(x => x.DeleteTeam(It.IsAny<Guid>()));
        }

        [Fact]
        public void DeleteTeam_ShouldDeleteLocation()
        {
            SetContext();
            var handler = new DeleteTeamCommandHandler(_teamsRepository.Object);
            var request = new DeleteTeamCommand { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") };

            var result = handler.Handle(request, CancellationToken.None);

            _teamsRepository.Verify(x => x.DeleteTeam(It.IsAny<Guid>()), Times.Once);
        }
    }
}
