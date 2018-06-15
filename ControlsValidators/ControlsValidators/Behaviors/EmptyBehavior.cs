using ControlsValidators.Behaviors.Base;
using Xamarin.Forms;

namespace ControlsValidators.Behaviors
{
    public class EmptyBehavior : BehaviorBase
    {
        protected override void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            base.HandleTextChanged(sender, e);

            CleanErrorMessage(sender);
            IsValid = !string.IsNullOrWhiteSpace(e.NewTextValue);

            if (!IsValid)
            {
                SetErrorMessage(sender);
            }
        }
    }
}
