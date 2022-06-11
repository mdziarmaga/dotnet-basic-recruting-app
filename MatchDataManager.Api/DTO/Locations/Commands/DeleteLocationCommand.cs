
namespace MatchDataManager.Api.DTO.Locations.Commands
{
    public class DeleteLocationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
