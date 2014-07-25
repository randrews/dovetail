using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Tags;

namespace PizzaWeb.Conventions
{
    public class PizzaWebHtmlConventions : HtmlConventionRegistry
    {
        public PizzaWebHtmlConventions()
        {
            Editors.Builder<PhoneNumberConvention>();
            Editors.Builder<EntityListBuilder>();


            Profile(TagProfile.DEFAULT, x => x.UseLabelAndFieldLayout<FieldLayoutConvention>());
        }
    }
}