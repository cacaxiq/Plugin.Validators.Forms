using System;
using Xamarin.Forms;

namespace ControlsValidators.Behaviors.Base
{
    public abstract class BehaviorBase : Behavior<View>, IDisposable
    {
        private bool FirstValidation = true;
        private bool disposed = false;

        protected override void OnAttachedTo(View bindable)
        {
            if (bindable is Entry entry)
            {
                entry.TextChanged += HandleTextChanged;
                base.OnAttachedTo(bindable);
            }
        }

        protected override void OnDetachingFrom(View bindable)
        {
            if (bindable is Entry entry)
            {
                entry.TextChanged -= HandleTextChanged;
                base.OnDetachingFrom(bindable);
            }

            Dispose(true);
        }

        protected virtual void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = false;
            if (FirstValidation)
                FirstValidation = false;
        }

        #region IsValid
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EmptyBehavior), false, BindingMode.OneWayToSource);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }
        #endregion

        #region ErrorMessage
        public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(EmptyBehavior), "Somente números", BindingMode.OneWayToSource);

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        #endregion

        #region ErrorMessage
        protected void SetErrorMessage(object sender)
        {
            var parent = ((Entry)sender).Parent;
            if (parent != null)
            {
                var labelError = parent.FindByName<Label>("errorMessage");
                labelError.Text = ErrorMessage;
            }
        }

        protected void CleanErrorMessage(object sender)
        {
            var parent = ((Entry)sender).Parent;
            if (parent != null)
            {
                var labelError = parent.FindByName<Label>("errorMessage");
                labelError.Text = string.Empty;
            }
        }
        #endregion

        #region Dispose     
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Dispose(disposing);
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }
        #endregion

        ~BehaviorBase()
        {
            Dispose(false);
        }
    }
}
