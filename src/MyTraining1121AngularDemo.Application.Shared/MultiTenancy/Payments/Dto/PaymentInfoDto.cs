using MyTraining1121AngularDemo.Editions.Dto;

namespace MyTraining1121AngularDemo.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < MyTraining1121AngularDemoConsts.MinimumUpgradePaymentAmount;
        }
    }
}
