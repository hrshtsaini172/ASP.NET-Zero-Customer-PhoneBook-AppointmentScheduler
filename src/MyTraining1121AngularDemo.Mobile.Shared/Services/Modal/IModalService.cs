using System.Threading.Tasks;
using MyTraining1121AngularDemo.Views;
using Xamarin.Forms;

namespace MyTraining1121AngularDemo.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
