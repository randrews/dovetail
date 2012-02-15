using FubuMVC.Core;
using FubuMVC.WebForms;
using PizzaWeb.Handlers;
using PizzaWeb.Handlers.Home;

namespace PizzaWeb.Bootstrap
{
    public class PizzaWebFubuRegistry : FubuRegistry
    {
        public PizzaWebFubuRegistry()
        {
            IncludeDiagnostics(true);
            
            Applies
                .ToThisAssembly();

            ApplyHandlerConventions<HandlerToken>();

            Routes
                .HomeIs<HomeHandler>(h => h.Execute())
                .IgnoreControllerNamesEntirely();
            
            Views
                .TryToAttachWithDefaultConventions();

            Import<WebFormsEngine>();
        }
    }
}