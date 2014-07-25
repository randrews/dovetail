using System;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.SessionState;
using FubuTestingSupport;
using NUnit.Framework;
using PizzaWeb.Data;
using Rhino.Mocks;
using System.Collections.Generic;
using PizzaWeb.Handlers.Orders;

namespace PizzaWeb.Test.Handlers
{
    [TestFixture]
    public class OrdersGetHandlerTester : InteractionContext<get_handler>
    {
        private IEnumerable<PickupOrder> result;
        private PickupOrder order;

        protected override void beforeEach()
        {
            order = new PickupOrder { Id = Guid.NewGuid() };
            Services.Get<IRepository>().Save(order);
            result = ClassUnderTest.Execute(new OrdersListStart());
        }

        [Test]
        public void should_get_orders()
        {
            Services.Get<IRepository>().AssertWasCalled(r => r.GetAll<PickupOrder>());
        }
    }
}