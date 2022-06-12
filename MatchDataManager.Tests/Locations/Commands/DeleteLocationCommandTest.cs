using MatchDataManager.Api.DTO.Locations.Commands;
using MatchDataManager.Api.Infrastructure.Handlers.Locations;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Tests.Locations.Commands
{
    public class DeleteLocationCommandTest
    {
        private readonly Mock<ILocationRepository> _locationRepository;
        public DeleteLocationCommandTest()
        {
            _locationRepository = new Mock<ILocationRepository>();
        }

        private void SetContext()
        {
            _locationRepository.Setup(x => x.DeleteLocation(It.IsAny<Guid>()));
        }

        [Fact]
        public void DeleteLocation_ShouldDeleteLocation()
        {
            SetContext();
            var handler = new DeleteLocationCommandHandler(_locationRepository.Object);
            var request = new DeleteLocationCommand { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") };

            var result = handler.Handle(request, CancellationToken.None);

            _locationRepository.Verify(x => x.DeleteLocation(It.IsAny<Guid>()), Times.Once);
        }
    }
}
