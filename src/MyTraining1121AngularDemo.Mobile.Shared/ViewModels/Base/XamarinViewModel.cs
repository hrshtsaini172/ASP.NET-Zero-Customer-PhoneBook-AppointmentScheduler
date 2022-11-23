using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.ObjectMapping;
using Acr.UserDialogs;
using MyTraining1121AngularDemo.Core.Dependency;
using MyTraining1121AngularDemo.Localization;
using MyTraining1121AngularDemo.Services.Modal;
using MyTraining1121AngularDemo.Services.Navigation;

namespace MyTraining1121AngularDemo.ViewModels.Base
{
    public abstract class XamarinViewModel : ExtendedBindableObject, ITransientDependency
    {
        private bool _isBusy;
        protected readonly INavigationService NavigationService;
        protected readonly IModalService ModalService;
        public IObjectMapper ObjectMapper { get; set; }

        public bool IsNotBusy => !IsBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
                RaisePropertyChanged(() => IsNotBusy);
            }
        }

        protected XamarinViewModel()
        {
            ModalService = DependencyResolver.Resolve<IModalService>(); ;
            NavigationService = DependencyResolver.Resolve<INavigationService>();
            ObjectMapper = NullObjectMapper.Instance;
        }

        public virtual async Task InitializeAsync(object navigationData)
        {
            await Task.FromResult(false);
        }

        public object GetPropertyValue(string propertyName)
        {
            return GetType().GetProperty(propertyName).GetValue(this, null);
        }

        public T GetPropertyValue<T>(string propertyName)
        {
            var value = GetPropertyValue(propertyName);
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public async Task SetBusyAsync(Func<Task> func, string loadingMessage = null)
        {
            if (loadingMessage == null)
            {
                loadingMessage = L.Localize("LoadWithThreeDot");
            }

            UserDialogs.Instance.ShowLoading(loadingMessage, MaskType.None);
            IsBusy = true;

            try
            {
                await func();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
                IsBusy = false;
            }
        }
    }
}