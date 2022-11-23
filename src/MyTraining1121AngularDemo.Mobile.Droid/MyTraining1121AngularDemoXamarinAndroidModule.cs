﻿using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyTraining1121AngularDemo
{
    [DependsOn(typeof(MyTraining1121AngularDemoXamarinSharedModule))]
    public class MyTraining1121AngularDemoXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTraining1121AngularDemoXamarinAndroidModule).GetAssembly());
        }
    }
}