using FubuMVC.Core.Continuations;
using FubuMVC.Core.SessionState;
using PizzaWeb.Data;
using PizzaWeb.Handlers.Home;

namespace PizzaWeb.Handlers.PlaceOrder
{
    public class post_handler
    {
        private readonly IRepository _repository;
        private readonly IFlash _flash;

        public post_handler(IRepository repository, IFlash flash)
        {
            _repository = repository;
            _flash = flash;
        }


        public FubuContinuation Execute(PickupOrder order)
        {
            _repository.Save(order);

            _flash.Flash(new[]{"Order placed successfully! Your Order ID is: " + order.Id});

            return FubuContinuation.RedirectTo<HomeModel>();
        }
    }
}