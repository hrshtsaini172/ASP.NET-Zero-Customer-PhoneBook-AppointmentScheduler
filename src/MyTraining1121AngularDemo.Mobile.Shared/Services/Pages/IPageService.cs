using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyTraining1121AngularDemo.Services.Pages
{
    public interface IPageService
    {
        Page MainPage { get; set; }

        Task<Page> CreatePage(Type viewType, object navigationParameter);
    }
}
