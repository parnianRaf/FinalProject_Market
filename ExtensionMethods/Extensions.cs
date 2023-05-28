using AppCore;

namespace ExtensionMethods;
public static class Extensions
{
    public static string FullNameToString(this User user )
    {
        return $"{user.FirstName} {user.LastName}";
    }

}

