namespace MatchDataManager.Api.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public Guid Id { get; }
        public NotFoundException(Guid id) : base($"Entity for guid '{id}' not found. ")
        {
            Id = id;
        }
    }
}
