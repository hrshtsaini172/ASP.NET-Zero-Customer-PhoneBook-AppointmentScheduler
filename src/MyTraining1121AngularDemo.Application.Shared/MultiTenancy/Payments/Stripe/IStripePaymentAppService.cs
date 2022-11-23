using System.Threading.Tasks;
using Abp.Application.Services;
using MyTraining1121AngularDemo.MultiTenancy.Payments.Dto;
using MyTraining1121AngularDemo.MultiTenancy.Payments.Stripe.Dto;

namespace MyTraining1121AngularDemo.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}