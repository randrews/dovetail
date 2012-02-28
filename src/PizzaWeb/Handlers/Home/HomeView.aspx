<%@ Page Language="C#" Inherits="PizzaWeb.Handlers.Home.HomeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Hipster Pi</title>
    </head>
    <body>
        <div><%= this.Partial<GetFlashes>() %></div>
        <%= this.LinkTo<PlaceOrderStart>().Text("Place an order!") %>
    </body>
</html>
