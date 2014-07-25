using FubuMVC.Core.UI.Configuration;
using HtmlTags;
using PizzaWeb.Data;
using System;

namespace PizzaWeb.Conventions
{
    public class PhoneNumberConvention : ElementBuilder
    {
        protected override bool matches(AccessorDef def)
        {
            return def.Accessor.PropertyType.Equals(typeof(PhoneNumber));
        }

        public override HtmlTag Build(ElementRequest request)
        {
            HtmlTag control = new HtmlTag("p").AddClass("phone-number");
            control.Append(new HtmlTag("label").Append("span").Text("Phone number"));
            control.Append(new HtmlTag("span").Text(" ( "));
            control.Append(new HtmlTag("input").Attr("type", "text").Attr("maxlength", "3").Attr("name", "AreaCode"));
            control.Append(new HtmlTag("span").Text(" ) "));
            control.Append(new HtmlTag("input").Attr("type", "text").Attr("maxlength", "3").Attr("name", "Prefix"));
            control.Append(new HtmlTag("span").Text(" - "));
            control.Append(new HtmlTag("input").Attr("type", "text").Attr("maxlength", "4").Attr("name", "Suffix"));
            return control;
        }
    }
}