using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MyTraining1121AngularDemo.Web.Public.Views
{
    public abstract class MyTraining1121AngularDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MyTraining1121AngularDemoRazorPage()
        {
            LocalizationSourceName = MyTraining1121AngularDemoConsts.LocalizationSourceName;
        }
    }
}
