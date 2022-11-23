using MyTraining1121AngularDemo.Core;
using MyTraining1121AngularDemo.Views;
using Xamarin.Forms;

namespace MyTraining1121AngularDemo.Controls
{
    public partial class LabelSection : ContentView, IXamarinView
    {
        public LabelSection()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(LabelSection), string.Empty);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == TextProperty.PropertyName)
            {
                SectionLabel.Text = Device.RuntimePlatform == Device.iOS ? Text.ToUpperInvariant() : Text;
            }
        }
    }
}