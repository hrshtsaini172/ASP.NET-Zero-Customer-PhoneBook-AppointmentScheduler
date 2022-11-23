using System.ComponentModel;
using Abp.AutoMapper;
using MyTraining1121AngularDemo.MultiTenancy.Dto;

namespace MyTraining1121AngularDemo.Models.Tenants
{
    [AutoMapFrom(typeof(TenantEditDto))]
    public class TenantEditModel : TenantEditDto, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}