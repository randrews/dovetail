using System;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.SessionState;
using FubuTestingSupport;
using NUnit.Framework;
using PizzaWeb.Data;
using PizzaWeb.Handlers.Home;
using PizzaWeb.Handlers.PlaceOrder;
using Rhino.Mocks;

namespace PizzaWeb.Test.Handlers
{
    [TestFixture]
    public class PlaceOrderPostHandlerTester : InteractionContext<post_handler>
    {
        private PickupOrder order;
        private FubuContinuation result;

        protected override void beforeEach()
        {
            order = new PickupOrder { Id = Guid.NewGuid() };
            result = ClassUnderTest.Execute(order);
        }

        [Test]
        public void should_save_order()
        {
            Services.Get<IRepository>().AssertWasCalled(r => r.Save(order));
        }

        [Test]
        public void should_flash()
        {
            Services.Get<IFlash>().AssertWasCalled(
                r => r.Flash(Arg<String[]>.Matches(s => s.Length == 1)));
        }

        [Test]
        public void should_flash_success()
        {
            Services.Get<IFlash>().AssertWasCalled(
                r => r.Flash(Arg<String[]>.Matches(s => s[0].Contains("success"))));
        }

        [Test]
        public void should_flash_orderID()
        {
            Services.Get<IFlash>().AssertWasCalled(
                r => r.Flash(Arg<String[]>.Matches(s => s[0].Contains(order.Id.ToString()))));
        }

        [Test]
        public void should_redirect_back_to_home()
        {
            result.AssertWasRedirectedTo<HomeModel>(h => h != null);
        }
    }
}