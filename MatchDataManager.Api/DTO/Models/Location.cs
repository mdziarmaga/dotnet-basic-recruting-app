using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.DTO.Models;

public class Location : Entity
{
    public string Name { get; set; }
    public string City { get; set; }
}