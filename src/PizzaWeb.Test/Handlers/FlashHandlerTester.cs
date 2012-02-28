using FubuMVC.Core.SessionState;
using FubuTestingSupport;
using NUnit.Framework;
using PizzaWeb.Handlers.Flashes;
using Rhino.Mocks;

namespace PizzaWeb.Test.Handlers
{
    [TestFixture]
    public class FlashHandlerTester : InteractionContext<get_handler>
    {
        [Test]
        public void should_be_empty_if_no_flashes()
        {
            ClassUnderTest.Execute(null).ShouldBeEmpty();
        }

        [Test]
        public void should_render_a_ul_tag()
        {
            Services.Get<IFlash>().Stub(f => f.Retrieve<string[]>()).Return(new[] {"foo"});
            ClassUnderTest.Execute(null).ShouldStartWith("<ul>");
        }

        [Test]
        public void should_render_an_li_for_each_flash()
        {
            var flashes = new[] {"foo", "baz"};
            Services.Get<IFlash>().Stub(f => f.Retrieve<string[]>()).Return(flashes);
            var list = ClassUnderTest.Execute(null);
            list.ShouldContain(">foo<");
            list.ShouldContain(">baz<");
        }
    }
}