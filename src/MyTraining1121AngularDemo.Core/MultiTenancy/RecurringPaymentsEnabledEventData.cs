using Abp.Events.Bus;

namespace MyTraining1121AngularDemo.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}