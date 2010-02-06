<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<PageResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
    <h1>Edit: <%= Resource.Title %></h1>
    <div>
        <% using (scope(Xhtml.Form(Resource).Method("post"))) { %>            
            <%= Xhtml.TextArea(() => Resource.Content) %>
            <input type="submit" value="Save" />
        <% } %>
    </div>
</asp:Content>
