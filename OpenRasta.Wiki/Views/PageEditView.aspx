<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<PageResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
    <h1>Edit: <%= Resource.Title %></h1>
    <div>
        <% using (scope(Xhtml.Form(Resource).Method("post"))) { %>            
            <textarea name="content" cols="50" rows="20"><%= Resource.Content %></textarea>
            <input type="submit" value="Save" />
        <% } %>
    </div>
</asp:Content>
