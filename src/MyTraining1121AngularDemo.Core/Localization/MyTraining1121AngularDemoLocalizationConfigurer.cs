using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyTraining1121AngularDemo.Localization
{
    public static class MyTraining1121AngularDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    MyTraining1121AngularDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MyTraining1121AngularDemoLocalizationConfigurer).GetAssembly(),
                        "MyTraining1121AngularDemo.Localization.MyTraining1121AngularDemo"
                    )
                )
            );
        }
    }
}