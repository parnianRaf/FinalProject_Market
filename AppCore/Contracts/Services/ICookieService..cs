namespace Service
{
    public interface ICookieService
    {
        void SetCookies(int id, string key);
        string ReadCookies(string key);
    }
}