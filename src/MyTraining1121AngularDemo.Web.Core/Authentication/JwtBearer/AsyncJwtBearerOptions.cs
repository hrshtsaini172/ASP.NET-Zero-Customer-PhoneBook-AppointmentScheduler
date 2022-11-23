using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MyTraining1121AngularDemo.Web.Authentication.JwtBearer
{
    public class AsyncJwtBearerOptions : JwtBearerOptions
    {
        public readonly List<IAsyncSecurityTokenValidator> AsyncSecurityTokenValidators;
        
        private readonly MyTraining1121AngularDemoAsyncJwtSecurityTokenHandler _defaultAsyncHandler = new MyTraining1121AngularDemoAsyncJwtSecurityTokenHandler();

        public AsyncJwtBearerOptions()
        {
            AsyncSecurityTokenValidators = new List<IAsyncSecurityTokenValidator>() {_defaultAsyncHandler};
        }
    }

}
