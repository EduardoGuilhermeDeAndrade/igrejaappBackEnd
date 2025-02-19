namespace igreja.Application.Interfaces
{
    public interface IAuthService
    {
        string Login(string username, string password);
        Task<bool> LogoutAsync(string token);
    }
}
