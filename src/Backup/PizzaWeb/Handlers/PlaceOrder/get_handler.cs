using FubuMVC.WebForms;
using PizzaWeb.Data;

namespace PizzaWeb.Handlers.PlaceOrder
{
    public class get_handler
    {
        public PickupOrder Execute(PlaceOrderStart input)
        {
            return new PickupOrder();
        }
    }

    public class PlaceOrderStart{}

    public class PlaceOrderView : FubuPage<PickupOrder> { }
}