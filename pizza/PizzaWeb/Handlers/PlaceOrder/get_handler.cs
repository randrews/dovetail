using FubuMVC.WebForms;

namespace PizzaWeb.Handlers.PlaceOrder
{
    public class get_handler
    {
        public PlaceOrderStart Execute(PlaceOrderStart input)
        {
            return new PlaceOrderStart();
        }
    }

    public class PlaceOrderStart{}

    public class PlaceOrderView : FubuPage<PlaceOrderStart> { }
}