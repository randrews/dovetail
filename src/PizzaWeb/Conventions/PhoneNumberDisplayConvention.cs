using FubuMVC.Core.UI.Configuration;
using HtmlTags;
using PizzaWeb.Data;
using System;

namespace PizzaWeb.Conventions
{
    public class PhoneNumberDisplayConvention : ElementBuilder
    {
        protected override bool matches(AccessorDef def)
        {
            return def.Accessor.PropertyType.Equals(typeof(PhoneNumber));
        }

        public override HtmlTag Build(ElementRequest request)
        {
            PhoneNumber p = request.Accessor.GetValue(request.Model) as PhoneNumber;
            string str = string.Format("({0}) {1}-{2}", p.AreaCode, p.Prefix, p.Suffix);

            return new HtmlTag("span").Text(str);
        }
    }
}