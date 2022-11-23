using System.Threading.Tasks;
using Abp.Webhooks;

namespace MyTraining1121AngularDemo.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
