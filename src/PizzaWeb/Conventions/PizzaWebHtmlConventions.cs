using FubuMVC.Core.UI;

namespace PizzaWeb.Conventions
{
    public class PizzaWebHtmlConventions : HtmlConventionRegistry
    {
        public PizzaWebHtmlConventions()
        {
            Editors.Builder<EntityListBuilder>();
        }
    }
}