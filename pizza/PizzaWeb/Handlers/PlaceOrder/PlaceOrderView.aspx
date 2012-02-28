<%@ Page Language="C#" Inherits="PizzaWeb.Handlers.PlaceOrder.PlaceOrderView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Hipster Pi : Place an Order</title>
    </head>
    <body>
        <div><%= this.Partial<GetFlashes>() %></div>
        <h1>Place an Order for Pickup</h1>
        <%= this.FormFor<PickupOrder>() %>
            
            <p>
                <label><span>Name on order:</span> <%= this.InputFor(new PickupOrder(), m => m.Name) %></label>
            </p>
            
            <p>
                <label><span>Location for pickup: </span> <%= this.InputFor(new PickupOrder(), m => m.Store)%></label>
            </p>
            <p>
                <label><span>Pizza: </span> <%= this.InputFor(new PickupOrder(), m => m.PizzaType)%></label>
            </p>
            <p><input type="submit" value="Submit your order"/></p>
        <%= this.EndForm() %>
    </body>
</html>
