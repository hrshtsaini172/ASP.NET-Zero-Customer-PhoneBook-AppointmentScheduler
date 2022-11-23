using MyTraining1121AngularDemo.Models.Tenants;
using MyTraining1121AngularDemo.ViewModels;
using Xamarin.Forms;

namespace MyTraining1121AngularDemo.Views
{
    public partial class TenantsView : ContentPage, IXamarinView
    {
        public TenantsView()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((TenantsViewModel)BindingContext).LoadMoreTenantsIfNeedsAsync(e.Item as TenantListModel);
        }
    }
}