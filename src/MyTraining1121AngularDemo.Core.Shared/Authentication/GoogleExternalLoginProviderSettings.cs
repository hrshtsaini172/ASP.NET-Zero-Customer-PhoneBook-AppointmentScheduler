﻿using Abp.Extensions;

namespace MyTraining1121AngularDemo.Authentication
{
    public class GoogleExternalLoginProviderSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UserInfoEndpoint { get; set; }
        
        public bool IsValid()
        {
            return !ClientId.IsNullOrWhiteSpace() && !ClientSecret.IsNullOrWhiteSpace();
        }
    }
}
