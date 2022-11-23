using System.Threading.Tasks;
using MyTraining1121AngularDemo.Authorization.Users;

namespace MyTraining1121AngularDemo.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
