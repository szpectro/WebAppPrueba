using System.Threading.Tasks;

namespace WEBapi.Services
{
    public interface IWebApi
    {
        Task<string> GetToken(string username, string password);
        Task<string> GetUsers();
    }
}
