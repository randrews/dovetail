using System;
using System.Reflection;
using FubuCore;
using FubuCore.Binding;
using PizzaWeb.Data;

namespace PizzaWeb.Conventions
{
    public class EntityPropertyConverter : StatelessConverter
    {
        public override bool Matches(PropertyInfo property)
        {
            return property.PropertyType.CanBeCastTo<Entity>();
        }

        public override object Convert(IPropertyContext context)
        {
            var entityType = context.Property.PropertyType;
            var repo = context.Service<IRepository>();
            var id = context.ValueAs<Guid?>();

            return (id.HasValue) ? repo.Get(entityType, id.Value) : null;
        }
    }
}