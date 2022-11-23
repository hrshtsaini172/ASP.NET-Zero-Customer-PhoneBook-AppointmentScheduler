using System.Threading.Tasks;
using MyTraining1121AngularDemo.Sessions.Dto;

namespace MyTraining1121AngularDemo.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
