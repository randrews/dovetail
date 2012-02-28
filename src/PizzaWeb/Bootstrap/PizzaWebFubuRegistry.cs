using FubuMVC.Core;
using FubuMVC.Validation;
using FubuMVC.WebForms;
using PizzaWeb.Conventions;
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
                .HomeIs<HomeModel>()
                .IgnoreControllerNamesEntirely();
            
            Views
                .TryToAttachWithDefaultConventions();

            this.Validation(x => x.Failures.ApplyPolicy<PlaceOrderValidationFailurePolicy>());

            StringConversions<PizzaWebStringifierConventions>();
            
            HtmlConvention<PizzaWebHtmlConventions>();
            
            Models.ConvertUsing<EntityPropertyConverter>();

            Import<WebFormsEngine>();
        }
    }
}