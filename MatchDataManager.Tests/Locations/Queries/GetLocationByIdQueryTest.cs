using MatchDataManager.Api.DTO.Locations.Queries;
using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Infrastructure.Handlers.Locations;
using MatchDataManager.Api.Repositories;
using MatchDataManager.Tests.Locations.Helpers;

namespace MatchDataManager.Tests.Locations.Queries
{
    public class GetLocationByIdQueryTest
    {
        private readonly Mock<ILocationRepository> _locationRepository;
        public GetLocationByIdQueryTest()
        {
            _locationRepository = new Mock<ILocationRepository>();
        }

        private void SetContext()
        {
            _locationRepository.Setup(x => x.GetLocationById(It.IsAny<Guid>())).ReturnsAsync(LocationHelper.Get().First()); 
        }

        [Fact]
        public void GetLocationById_ShouldReturnLocation()
        {
            SetContext();
            var id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var handler = new GetLocationByIdQueryHandler(_locationRepository.Object);
            var request = new GetLocationByIdQuery { Id = id };

            var result = handler.Handle(request, CancellationToken.None);

            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType<Location>();
            Assert.Equal("test name1", result.Result.Name);
            Assert.Equal("city test1", result.Result.City);
        }
    }
}
