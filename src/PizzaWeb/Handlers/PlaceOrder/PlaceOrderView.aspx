<%@ Page Language="C#" MasterPageFile="../../Content/Main.master" Inherits="PizzaWeb.Handlers.PlaceOrder.PlaceOrderView" Title="Hipster Pi: Place an order" %>
<%@ Import Namespace="PizzaWeb.Handlers.Home" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <div class="page-header">
          <h1>Place an Order for Pickup</h1>
        </div>
        <div class="row">
          <div class="span3">
              <p><%= this.LinkTo<HomeModel>().Text("Back home") %></p>
              Just give us your name, select the store, and the type of pizza you want and we'll have it done and ready for you before it was cool!
              <ul class="thumbnails">
                  <li class="span3"><img runat="server" src="~/Content/Images/pp.jpg" alt="Pizza pi"/></li>
              </ul>
          </div>
          <div class="span9">
              <%= this.FormFor<PickupOrder>() %>
                    <%= this.Edit(m => m.FirstName) %>
                    <%= this.Edit(m => m.LastName) %>
                    <%= this.InputFor(m => m.PhoneNumber) %>
                    <%= this.Edit(m => m.Store)%>
                    <%= this.Edit(m => m.PizzaType)%>
                    <div class="form-actions">
                        <input type="submit" class="btn btn-primary" value="Submit your order"/>
                    </div>
                <%= this.EndForm() %>
          </div>
        </div>
        
</asp:Content>