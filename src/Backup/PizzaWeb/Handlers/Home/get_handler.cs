using FubuMVC.WebForms;

namespace PizzaWeb.Handlers.Home
{
    public class get_handler
    {
        public HomeViewModel Execute(HomeModel model)
        {
            return new HomeViewModel();
        }
    }

    public class HomeModel{}

    public class HomeViewModel{}

    public class HomeView : FubuPage<HomeViewModel> { }
}