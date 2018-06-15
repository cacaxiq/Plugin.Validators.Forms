using ControlsValidators.Behaviors.Base;
using Xamarin.Forms;

namespace ControlsValidators.Behaviors
{
    public class NumericOnlyBehavior : BehaviorBase
    {
        protected override void OnAttachedTo(View bindable)
        {
            if (bindable is Entry entry)
            {
               entry.Keyboard = Keyboard.Numeric;
            }

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            if (bindable is Entry entry)
            {
                entry.Keyboard = Keyboard.Default;
            }

            base.OnDetachingFrom(bindable);

            Dispose(true);
        }

        protected override void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            base.HandleTextChanged(sender, e);

            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                CleanErrorMessage(sender);
                IsValid = int.TryParse(e.NewTextValue, out int value);
            }

            if (!IsValid)
            {
                SetErrorMessage(sender);
                var entry = sender as Entry;
            }
        }
    }
}
