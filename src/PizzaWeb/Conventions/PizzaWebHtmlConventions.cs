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
            
            Displays.Builder<PhoneNumberDisplayConvention>();

            Profile(TagProfile.DEFAULT, x => x.UseLabelAndFieldLayout<FieldLayoutConvention>());
        }
    }
}