using System;
using Abp.AutoMapper;
using MyTraining1121AngularDemo.Sessions.Dto;

namespace MyTraining1121AngularDemo.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}