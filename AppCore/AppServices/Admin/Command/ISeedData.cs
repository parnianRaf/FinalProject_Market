namespace AppService.Admin
{
    public interface ISeedData
    {
        Task<bool> Execute();
    }
}