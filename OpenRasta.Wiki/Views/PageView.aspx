<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<PageResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
    <h1><%= Resource.Title %></h1>
    <div>
        <%= Resource.Content %>
    </div>
</asp:Content>
