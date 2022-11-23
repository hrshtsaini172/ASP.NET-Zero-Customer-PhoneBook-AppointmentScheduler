using Abp.AspNetCore.Mvc.Views;

namespace MyTraining1121AngularDemo.Web.Views
{
    public abstract class MyTraining1121AngularDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MyTraining1121AngularDemoRazorPage()
        {
            LocalizationSourceName = MyTraining1121AngularDemoConsts.LocalizationSourceName;
        }
    }
}
