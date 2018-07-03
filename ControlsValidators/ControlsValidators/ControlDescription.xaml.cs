using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlsValidators
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlDescription : StackLayout
    {
        #region Description
        public static readonly BindableProperty DescriptionProperty =
           BindableProperty.Create(nameof(Description), typeof(string),
               typeof(ControlDescription), string.Empty, BindingMode.Default, null, DescriptionPropertyChanged);

        private static void DescriptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ControlDescription;
            control.description.Text = newValue.ToString();
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
        #endregion

        #region Label
        public static readonly BindableProperty LabelProperty =
            BindableProperty.Create(
                nameof(Label),
                typeof(string),
                typeof(ControlDescription),
                string.Empty,
                BindingMode.OneWayToSource,
                null,
                LabelPropertyChanged);

        private static void LabelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ControlDescription;
            control.label.Text = newValue.ToString();
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        #endregion
        
        public ControlDescription()
        {
            InitializeComponent();
        }
    }
}