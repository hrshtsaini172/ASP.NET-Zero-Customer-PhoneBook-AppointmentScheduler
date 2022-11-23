using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.WebHooks.Dto
{
    public class GetAllSendAttemptsInput : PagedInputDto
    {
        public string SubscriptionId { get; set; }
    }
}
