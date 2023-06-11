namespace AppCore.Contracts.AppServices.Account
{
    public interface IMapServices
    {
        User MapUser<T>(T userDto);
        List<T> MapUser<T>(List<User> users);
        T MapUser<T>(User user);
    }
}