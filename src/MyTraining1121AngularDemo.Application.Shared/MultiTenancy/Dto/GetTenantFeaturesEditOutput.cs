using System.Collections.Generic;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.Editions.Dto;

namespace MyTraining1121AngularDemo.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}