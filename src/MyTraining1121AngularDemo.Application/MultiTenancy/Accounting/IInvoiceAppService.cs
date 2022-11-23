using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.MultiTenancy.Accounting.Dto;

namespace MyTraining1121AngularDemo.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
