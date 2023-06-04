namespace AppCore.AppServices.Admin_.Command
{
    public interface ISeedData
    {
        Task<bool> Execute();
    }
}