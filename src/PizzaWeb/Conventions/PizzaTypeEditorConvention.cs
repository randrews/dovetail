using FubuCore;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;
using PizzaWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaWeb.Conventions
{
    class PizzaTypeEditorConvention : ElementBuilder
    {
        protected override bool matches(AccessorDef def)
        {
            return def.Accessor.PropertyType.Equals(typeof(PizzaType));
        }

        public override HtmlTags.HtmlTag Build(ElementRequest request)
        {
            HtmlTag el = new HtmlTag("ul").AddClass("pizza-type");

            IEnumerable<PizzaType> pizzaTypes = request.Get<IRepository>().GetAll(typeof(PizzaType)).Cast<PizzaType>();
            var stringifier = request.Get<Stringifier>();

            foreach (PizzaType pt in pizzaTypes)
            {
                HtmlTag radio = new HtmlTag("input");
                radio.Attr("type", "radio").Attr("name", "PizzaType");
                radio.Attr("value", pt.Id);
                radio.Text(stringifier.GetString(pt));
                el.Append(new HtmlTag("li").Append(radio));
            }

            return el;
        }
    }
}
