using PizzaWeb.Data;
using StructureMap.Configuration.DSL;
using FubuValidation.StructureMap;

namespace PizzaWeb.Bootstrap
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            // Not real-world, just used to eliminate persistence problems and questions from the test
            For<IRepository>().Singleton().Use<DataRepository>().OnCreation(r => r.LoadDefaultSampleData());

            this.FubuValidation();

            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.WithDefaultConventions();
                     });
        }
    }
}