namespace AppCore.Contracts.Services
{
    public interface IIdGeneratorService
    {
        int Execute<T>(List<T> entities);
    }
}