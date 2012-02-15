using StructureMap.Configuration.DSL;

namespace PizzaWeb.Bootstrap
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.WithDefaultConventions();
                     });
        }
    }
}