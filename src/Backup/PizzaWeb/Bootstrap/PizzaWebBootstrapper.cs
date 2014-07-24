using StructureMap;

namespace PizzaWeb.Bootstrap
{
    public class PizzaWebBootstrapper
    {
        public static IContainer BuildContainer()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<StructureMapRegistry>());
            return ObjectFactory.Container;
        }
    }
}