using FubuMVC.WebForms;

namespace PizzaWeb.Handlers.Home
{
    public class HomeHandler
    {
       public HomeViewModel Execute()
       {
           return new HomeViewModel();
       }
    }

    public class HomeViewModel
    {
    }

    public class HomeView : FubuPage<HomeViewModel>{}
}