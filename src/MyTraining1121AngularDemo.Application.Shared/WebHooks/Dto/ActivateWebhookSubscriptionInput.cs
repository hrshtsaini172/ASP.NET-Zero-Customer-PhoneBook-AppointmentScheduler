using System;

namespace MyTraining1121AngularDemo.WebHooks.Dto
{
    public class ActivateWebhookSubscriptionInput
    {
        public Guid SubscriptionId { get; set; }

        public bool IsActive { get; set; }
    }
}
