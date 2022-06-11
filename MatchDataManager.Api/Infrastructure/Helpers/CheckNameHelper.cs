using MatchDataManager.Api.Exceptions;

namespace MatchDataManager.Api.Helpers
{
    public static class CheckNameHelper 
    {
        public static void CheckName(string name, string newName, string currentName)
        {
            if (!currentName.Equals(newName) && name.Equals(newName))
                throw new NameExistException(name);
        }
    }
}
