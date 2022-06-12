using MatchDataManager.Api.DTO.Locations.Commands;
using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Exceptions;
using MatchDataManager.Api.Infrastructure.Exceptions;
using MatchDataManager.Api.Infrastructure.Handlers.Locations;
using MatchDataManager.Api.Repositories;
using MatchDataManager.Tests.Locations.Helpers;

namespace MatchDataManager.Tests.Locations.Commands
{
    public class UpdateLocationCommandTest
    {
        private readonly Mock<ILocationRepository> _locationRepository;
        public UpdateLocationCommandTest()
        {
            _locationRepository = new Mock<ILocationRepository>();
        }

        private void SetContext()
        {
            _locationRepository.Setup(x => x.UpdateLocation(It.IsAny<Location>())).ReturnsAsync(LocationHelper.Get().FirstOrDefault());
        }

        [Fact]
        public void UpdateLocation_ShouldThrowNotFoundException()
        {
            SetContext();
            var handler = new UpdateLocationCommandHandler(_locationRepository.Object);
            var request = new UpdateLocationCommand { Location = new Location { Id = new Guid(), Name = "new name", City="new city" } };

            var result = handler.Handle(request, CancellationToken.None);

            Assert.ThrowsAsync<NotFoundException>(() => result);        
        }

        [Fact]
        public void UpdateLocation_ShouldThrowNameExistException()
        {
            SetContext();
            var handler = new UpdateLocationCommandHandler(_locationRepository.Object);
            var request = new UpdateLocationCommand { Location = new Location { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Name = "test name2", City="new city" } };

            var result = handler.Handle(request, CancellationToken.None);

            Assert.ThrowsAsync<NameExistException>(() => result);
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "", "name1")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", " ", "name1")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", null, "name1")]
        public void UpdateLocation_ShouldReturnInformationAboutCityRequiredField(Guid id, string city, string name)
        {
            var validator = new LocationValidator();
            var location = new Location() { Id = id, City = city, Name = name };

            var result = validator.Validate(location);

            result.Equals("City is required.");
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "city1", "")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "city1", " ")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "city1", null)]
        public void UpdateLocation_ShouldReturnInformationAboutNameRequiredField(Guid id, string city, string name)
        {
            var validator = new LocationValidator();
            var location = new Location() { Id = id, City = city, Name = name };

            var result = validator.Validate(location);

            result.Equals("Name is required.");
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "city1", "testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest")]
        public void UpdateLocation_ShouldReturnInformationAboutTooLongName(Guid id, string city, string name)
        {
            var validator = new LocationValidator();
            var location = new Location() { Id = id, City = city, Name = name };

            var result = validator.Validate(location);

            result.Equals("Length can't be longer than 255 signs.");
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest", "test name")]
        public void UpdateLocation_ShouldReturnInformationAboutTooLongCity(Guid id, string city, string name)
        {
            var validator = new LocationValidator();
            var location = new Location() { Id = id, City = city, Name = name };

            var result = validator.Validate(location);

            result.Equals("Length can't be longer than 55 signs.");
        }
    }
}
