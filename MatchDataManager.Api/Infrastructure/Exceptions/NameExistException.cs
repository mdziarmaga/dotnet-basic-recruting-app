namespace MatchDataManager.Api.Exceptions
{
    public class NameExistException : Exception
    {
        public string Name { get;}
        public NameExistException(string name) : base($"Name '{name}' already exist.")
        {
            Name = name;
        }
    }
}
