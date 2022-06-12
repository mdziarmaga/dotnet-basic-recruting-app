using MatchDataManager.Api.DTO.Locations.Queries;
using MatchDataManager.Api.Infrastructure.Handlers.Locations;
using MatchDataManager.Api.Repositories;
using MatchDataManager.Tests.Locations.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Tests.Locations.Queries
{
    public class GetLocationsQueryTest
    {
        private readonly Mock<ILocationRepository> _locationRepository;
        public GetLocationsQueryTest()
        {
            _locationRepository = new Mock<ILocationRepository>();
        }

        private void SetContext()
        {
            _locationRepository.Setup(x => x.GetAllLocations()).ReturnsAsync(LocationHelper.Get());
        }

        [Fact]
        public void GetLocations_ShouldReturnProperValues()
        {
            SetContext();
            var handler = new GetLocationsQueryHandler(_locationRepository.Object);
            var request = new GetLocationsQuery();

            var result = handler.Handle(request, CancellationToken.None);

            result.Result.Should().NotBeNull();
            Assert.Equal(2, result.Result.Count());
        }
    }
}
