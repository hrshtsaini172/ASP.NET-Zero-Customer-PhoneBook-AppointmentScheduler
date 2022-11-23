using System.Collections.Generic;
using MvvmHelpers;
using MyTraining1121AngularDemo.Models.NavigationMenu;

namespace MyTraining1121AngularDemo.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}