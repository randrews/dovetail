using System.Linq;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.SessionState;
using FubuMVC.Validation;
using PizzaWeb.Data;
using PizzaWeb.Handlers.PlaceOrder;

namespace PizzaWeb.Conventions
{
    public class PlaceOrderValidationFailurePolicy : IValidationFailurePolicy
    {
        private readonly IFubuRequest _request;
        private readonly IValidationContinuationHandler _handler;
        private readonly IFlash _flash;

        public PlaceOrderValidationFailurePolicy(IFubuRequest request, IValidationContinuationHandler handler, IFlash flash)
        {
            _request = request;
            _handler = handler;
            _flash = flash;
        }

        public bool Matches(ValidationFailure context)
        {
            return context.InputType() == typeof (PickupOrder);
        }

        public void Handle(ValidationFailure context)
        {
            _flash.Flash(context.Notification.AllMessages.Select(m => m.ToString()));
            var continuation = FubuContinuation.RedirectTo<PlaceOrderStart>();
            _request.Set(continuation);
            _handler.Handle();
        }
    }
}