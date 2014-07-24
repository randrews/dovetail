<%@ Page Language="C#" MasterPageFile="../../Content/Main.master" Inherits="PizzaWeb.Handlers.Home.HomeView" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero-unit">
        <h1>Welcome to Hipster Pi</h1>
        <p>Pies so hip, we had to drop the 'e'</p>
        <p>
            <%= this.LinkTo<PlaceOrderStart>().Text("Place an order!").AddClasses("btn", "btn-primary", "btn-large") %>
        </p>
    </div>
    
    
</asp:Content>