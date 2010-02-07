<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<PageResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <h1><%= Resource.Title %></h1>
    <div id="pageContent">
        <%=(r) Resource.TransformedContent %>
    </div>
    <div id="edit">
        <a href="<%= Resource.CreateUri("edit") %>">
            Edit this page
        </a>        
    </div>
</asp:Content>
