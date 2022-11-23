using System;
using MyTraining1121AngularDemo.Core;
using MyTraining1121AngularDemo.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTraining1121AngularDemo.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return Text;
            }

            return L.Localize(Text);
        }
    }
}