using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyTraining1121AngularDemo.Web.Public.Views
{
    public abstract class MyTraining1121AngularDemoViewComponent : AbpViewComponent
    {
        protected MyTraining1121AngularDemoViewComponent()
        {
            LocalizationSourceName = MyTraining1121AngularDemoConsts.LocalizationSourceName;
        }
    }
}