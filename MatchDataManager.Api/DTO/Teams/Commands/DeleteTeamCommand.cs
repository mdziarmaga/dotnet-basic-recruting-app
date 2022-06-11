namespace MatchDataManager.Api.DTO.Teams.Commands
{
    public class DeleteTeamCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
