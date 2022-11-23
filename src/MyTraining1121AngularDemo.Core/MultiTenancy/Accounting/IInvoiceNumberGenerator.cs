using System.Threading.Tasks;
using Abp.Dependency;

namespace MyTraining1121AngularDemo.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}