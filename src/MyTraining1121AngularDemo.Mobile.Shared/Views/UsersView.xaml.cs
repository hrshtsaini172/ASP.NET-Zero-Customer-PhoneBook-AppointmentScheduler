using MyTraining1121AngularDemo.Models.Users;
using MyTraining1121AngularDemo.ViewModels;
using Xamarin.Forms;

namespace MyTraining1121AngularDemo.Views
{
    public partial class UsersView : ContentPage, IXamarinView
    {
        public UsersView()
        {
            InitializeComponent();
        }

        public async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((UsersViewModel) BindingContext).LoadMoreUserIfNeedsAsync(e.Item as UserListModel);
        }
    }
}