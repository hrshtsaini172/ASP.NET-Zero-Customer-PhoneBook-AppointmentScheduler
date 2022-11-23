using System;
using MyTraining1121AngularDemo.Core;
using MyTraining1121AngularDemo.Core.Dependency;
using MyTraining1121AngularDemo.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTraining1121AngularDemo.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}