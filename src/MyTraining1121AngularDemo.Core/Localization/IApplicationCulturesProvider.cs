using System.Globalization;

namespace MyTraining1121AngularDemo.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}