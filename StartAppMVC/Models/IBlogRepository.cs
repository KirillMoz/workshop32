using StartAppMVC.Models.Db;
using System.Threading.Tasks;

namespace StartAppMVC.Models
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
