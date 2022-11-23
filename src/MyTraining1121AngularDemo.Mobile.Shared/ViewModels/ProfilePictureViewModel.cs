using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using MyTraining1121AngularDemo.Core.Threading;
using MyTraining1121AngularDemo.ViewModels.Base;
using Xamarin.Forms;

namespace MyTraining1121AngularDemo.ViewModels
{
    public class ProfilePictureViewModel : XamarinViewModel
    {
        public ICommand CloseCommand => AsyncCommand.Create(ModalService.CloseModalAsync);

        private ImageSource _photo;

        public ImageSource Photo
        {
            get => _photo;
            set
            {
                _photo = value;
                RaisePropertyChanged(() => Photo);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            var profilePictureBytes = (byte[])navigationData;
            Photo = ImageSource.FromStream(() => new MemoryStream(profilePictureBytes));
            return Task.CompletedTask;
        }
    }
}
