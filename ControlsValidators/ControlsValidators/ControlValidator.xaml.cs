
using ControlsValidators.Behaviors.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlsValidators
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlValidator : ContentView
    {
        #region DescriptionValidator
        public static readonly BindableProperty DescriptionValidatorProperty =
           BindableProperty.Create(nameof(DescriptionValidator), typeof(string),
               typeof(ControlValidator), string.Empty, BindingMode.OneWayToSource, null, DescriptionValidatorPropertyChanged);

        private static void DescriptionValidatorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ControlValidator;
            control.descriptionValidator.Text = newValue.ToString();
        }

        public string DescriptionValidator
        {
            get { return (string)GetValue(DescriptionValidatorProperty); }
            set { SetValue(DescriptionValidatorProperty, value); }
        }
        #endregion

        #region EntryValidator
        public static readonly BindableProperty EntryValidatorProperty =
    BindableProperty.Create(nameof(EntryValidator), typeof(string),
        typeof(ControlValidator), string.Empty, BindingMode.OneWayToSource, null, EntryValidatorPropertyChanged);

        private static void EntryValidatorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as ControlValidator;
            control.entryValidator.Text = newValue.ToString();
        }

        public string EntryValidator
        {
            get { return (string)GetValue(EntryValidatorProperty); }
            set { SetValue(EntryValidatorProperty, value); }
        }
        #endregion

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == "Parent")
            {
                entryValidator.Behaviors.Clear();
                foreach (var behavior in Behaviors)
                    entryValidator.Behaviors.Add(behavior);
            }

            base.OnPropertyChanged(propertyName);
        }

        public ControlValidator()
        {
            InitializeComponent();
        }
    }
}