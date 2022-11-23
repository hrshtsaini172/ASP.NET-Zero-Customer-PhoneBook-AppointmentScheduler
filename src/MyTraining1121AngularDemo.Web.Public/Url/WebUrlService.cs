using Abp.Dependency;
using MyTraining1121AngularDemo.Configuration;
using MyTraining1121AngularDemo.Url;
using MyTraining1121AngularDemo.Web.Url;

namespace MyTraining1121AngularDemo.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}