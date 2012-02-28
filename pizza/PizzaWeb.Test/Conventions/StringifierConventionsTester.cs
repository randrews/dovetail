using FubuCore;
using FubuTestingSupport;
using NUnit.Framework;
using PizzaWeb.Conventions;
using PizzaWeb.Data;

namespace PizzaWeb.Test.Conventions
{
    [TestFixture]
    public class StringifierConventionsTester
    {
        private Stringifier stringifier;

        [SetUp]
        public void SetUp()
        {
            stringifier = new PizzaWebStringifierConventions().BuildStringifier();   
        }

        [Test]
        public void should_stringify_pizza_type()
        {
            var pizzaType = new PizzaType {Name = "foo", Description = "baz"};
            var result = stringifier.GetString(pizzaType);

            result.ShouldContain(pizzaType.Name);
            result.ShouldContain(pizzaType.Description);
        }

        [Test]
        public void should_stringify_store()
        {
            var store = new Store {StoreID = "foo", Name = "baz"};
            var result = stringifier.GetString(store);

            result.ShouldContain(store.StoreID);
            result.ShouldContain(store.Name);
        }
    }
}