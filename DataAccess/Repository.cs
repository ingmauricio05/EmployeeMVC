using EmployeesModel;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository : IRepository
    {
        private static Connector conector = new Connector();

        public async Task<JArray> MakeRequestGet(Request peticion)
        {
            var result = await conector.SendRequest(peticion);
            return result;
        }
    }
}
