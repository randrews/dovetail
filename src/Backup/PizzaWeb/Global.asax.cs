using System;
using System.Web;
using PizzaWeb.Bootstrap;

namespace PizzaWeb
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new PizzaWebApplication().BuildApplication().Bootstrap();
        }
    }
}