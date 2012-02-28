using System.Collections.Generic;
using System.Linq;
using FubuCore;
using FubuMVC.Core.UI.Configuration;
using HtmlTags;
using PizzaWeb.Data;

namespace PizzaWeb.Conventions
{
    public class EntityListBuilder : ElementBuilder
    {
        protected override bool matches(AccessorDef def)
        {
            return def.Accessor.PropertyType.CanBeCastTo<Entity>();
        }

        public override HtmlTag Build(ElementRequest request)
        {
            var entities = request.Get<IRepository>().GetAll(request.Accessor.PropertyType).Cast<Entity>();
            var stringifier = request.Get<Stringifier>();

            return new SelectTag(tag => 
                                 entities.Each(entity => tag.Option(stringifier.GetString(entity), entity.Id)));
        }
    }
}