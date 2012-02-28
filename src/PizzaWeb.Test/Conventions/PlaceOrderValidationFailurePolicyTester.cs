using FubuMVC.Core.Continuations;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.SessionState;
using FubuMVC.Validation;
using FubuValidation;
using NUnit.Framework;
using PizzaWeb.Conventions;
using PizzaWeb.Handlers.PlaceOrder;
using Rhino.Mocks;

namespace PizzaWeb.Test.Conventions
{
    [TestFixture]
    public class PlaceOrderValidationFailurePolicyTester
    {
        private InMemoryFubuRequest request;
        private IValidationContinuationHandler handler;
        private IFlash flash;
        private PlaceOrderValidationFailurePolicy policy;

        [SetUp]
        public void SetUp()
        {
            request = new InMemoryFubuRequest();
            handler = MockRepository.GenerateStub<IValidationContinuationHandler>();
            flash = MockRepository.GenerateStub<IFlash>();
            policy = new PlaceOrderValidationFailurePolicy(request, handler, flash);
            var notification = Notification.Invalid();
            var failure = new ValidationFailure(null, notification, null);
            policy.Handle(failure);
        }

        [Test]
        public void should_put_all_notifications_into_flash()
        {
            flash.AssertWasCalled(f => f.Flash(null), o=>o.IgnoreArguments());
        }

        [Test]
        public void should_signal_redirect_to_place_order_screen()
        {
            request
                .Get<FubuContinuation>()
                .AssertWasRedirectedTo<PlaceOrderStart>(s => s != null);
        }

        [Test]
        public void should_call_validation_handler_to_complete_request()
        {
            handler.AssertWasCalled(h => h.Handle());
        }
    }
}