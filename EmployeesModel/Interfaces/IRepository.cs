using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace EmployeesModel
{
    public interface IRepository
    {
        Task<JArray> MakeRequestGet(Request peticion);
    }
}
