using StartAppMVC.Models.Db;
using System.Threading.Tasks;

namespace StartAppMVC.Models
{
    public interface IRequestLogRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequest();
    }
}
