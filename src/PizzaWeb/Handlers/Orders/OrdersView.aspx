<%@ Page Language="C#" MasterPageFile="../../Content/Main.master" Inherits="PizzaWeb.Handlers.Orders.OrdersView" Title="Hipster Pi: All orders" %>
<%@ Import Namespace="PizzaWeb.Handlers.Home" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <div class="page-header">
          <h1>Orders for Pickup</h1>
        </div>
        <div class="row">
          <div class="span3">
              <p><%= this.LinkTo<HomeModel>().Text("Back home") %></p>
          </div>
          <div class="span9">
              Blah
          </div>
        </div>
        
</asp:Content>