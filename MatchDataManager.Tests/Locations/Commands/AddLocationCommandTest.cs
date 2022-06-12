using MatchDataManager.Api.DTO.Locations.Commands;
using MatchDataManager.Api.DTO.Models;
using MatchDataManager.Api.Exceptions;
using MatchDataManager.Api.Infrastructure.Handlers.Locations;
using MatchDataManager.Api.Repositories;

namespace MatchDataManager.Tests.Locations.Commands
{
    public class AddLocationCommandTest
    {
        private readonly Mock<ILocationRepository> _locationRepository;
        public AddLocationCommandTest()
        {
            _locationRepository = new Mock<ILocationRepository>();
        }
        private void SetContext(Location location)
        {
            _locationRepository.Setup(x => x.AddLocation(It.IsAny<Location>())).ReturnsAsync(location);
        }

        [Fact]
        public void AddLocation_ShouldSucceded()
        {
            var location = new Location { Id = Guid.NewGuid(), Name = "new name", City="new city" };
            SetContext(location);
            var handler = new AddLocationCommandHandler(_locationRepository.Object);
            var request = new AddLocationCommand { Location =  location };

            var result = handler.Handle(request, CancellationToken.None);

            _locationRepository.Verify(x => x.AddLocation(It.IsAny<Location>()), Times.Once);
            Assert.IsType<Location>(result.Result);
            Assert.Equal("new name", result.Result.Name);
            Assert.Equal("new city", result.Result.City);
        }

        [Fact]
        public void AddLocation_ShouldThrowNameExistException()
        {
            var location = new Location { Id = new Guid("3fa85f64-5717-4d62-b3fc-2c963f66afa6"), Name = "test name2", City="new city" };
            SetContext(location);
            var handler = new AddLocationCommandHandler(_locationRepository.Object);
            var request = new AddLocationCommand { Location = location };

            var result = handler.Handle(request, CancellationToken.None);

            Assert.ThrowsAsync<NameExistException>(() => result);
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "", "name1")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", " ", "name1")]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", null, "name1")]
        public void AddLocation_ShouldReturnInformationAboutCityRequiredField(Guid id, string city, string name)
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
        public void AddLocation_ShouldReturnInformationAboutNameRequiredField(Guid id, string city, string name)
        {
            var validator = new LocationValidator();
            var location = new Location() { Id = id, City = city, Name = name };

            var result = validator.Validate(location);

            result.Equals("Name is required.");
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "city1", "testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest")]
        public void AddLocation_ShouldReturnInformationAboutTooLongName(Guid id, string city, string name)
        {
            var validator = new LocationValidator();
            var location = new Location() { Id = id, City = city, Name = name };

            var result = validator.Validate(location);

            result.Equals("Length can't be longer than 255 signs.");
        }

        [Theory]
        [InlineData("3fa85f64-5717-4562-b3fc-2c963f66afa6", "testtest test test testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest", "test name")]
        public void AddLocation_ShouldReturnInformationAboutTooLongCity(Guid id, string city, string name)
        {
            var validator = new LocationValidator();
            var location = new Location() { Id = id, City = city, Name = name };

            var result = validator.Validate(location);

            result.Equals("Length can't be longer than 55 signs.");
        }
    }
}
