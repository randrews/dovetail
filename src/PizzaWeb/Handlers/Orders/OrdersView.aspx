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
              <table>
                  <thead>
                      <tr>
                          <th>First Name</th>
                          <th>Last Name</th>
                          <th>Phone Number</th>
                          <th>Store</th>
                          <th>Pizza type</th>
                      </tr>
                  </thead>
                  <tbody>
                      <% foreach(PickupOrder p in Model){ %>
                        <tr>
                            <td><%= p.FirstName %></td>
                            <td><%= p.LastName %></td>
                            <td><%= p.PhoneNumber %></td>
                            <td><%= p.Store %></td>
                            <td><%= p.PizzaType %></td>
                        </tr>
                      <% } %>
                  </tbody>
              </table>
          </div>
        </div>
        
</asp:Content>