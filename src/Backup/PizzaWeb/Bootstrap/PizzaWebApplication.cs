using FubuMVC.Core;
using FubuMVC.StructureMap;

namespace PizzaWeb.Bootstrap
{
    public class PizzaWebApplication : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            return FubuApplication.For<PizzaWebFubuRegistry>().StructureMap(PizzaWebBootstrapper.BuildContainer);
        }
    }
}