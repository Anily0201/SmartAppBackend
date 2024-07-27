using SmartAppBackend.Core.Models;
using System.Threading.Tasks;

namespace SmartAppBackend.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Register(User user);
    }
}
