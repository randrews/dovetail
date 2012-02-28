using FubuCore;
using PizzaWeb.Data;

namespace PizzaWeb.Conventions
{
    public class PizzaWebStringifierConventions : DisplayConversionRegistry
    {
        public PizzaWebStringifierConventions()
        {
            IfCanBeCastToType<Store>().ConvertBy(s => "Store #{0} : {1}".ToFormat(s.StoreID, s.Name));
            IfCanBeCastToType<PizzaType>().ConvertBy(p => "{0} ({1})".ToFormat(p.Name, p.Description));
        }
    }
}