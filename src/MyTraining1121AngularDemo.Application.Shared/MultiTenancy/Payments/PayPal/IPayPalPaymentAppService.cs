using System.Threading.Tasks;
using Abp.Application.Services;
using MyTraining1121AngularDemo.MultiTenancy.Payments.PayPal.Dto;

namespace MyTraining1121AngularDemo.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
