using StartAppMVC.Models.Db;
using System.Threading.Tasks;

namespace StartAppMVC.Models
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequest();
    }
}
