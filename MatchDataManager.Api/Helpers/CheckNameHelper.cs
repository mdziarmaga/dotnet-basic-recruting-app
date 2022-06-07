using MatchDataManager.Api.Exceptions;

namespace MatchDataManager.Api.Helpers
{
    public static class CheckNameHelper 
    {
        public static void CheckName(string name, string newName)
        {
            if (name.Equals(newName))
                throw new NameExistException(name);
        }
    }
}
