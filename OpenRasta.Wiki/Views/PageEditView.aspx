<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<PageResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <h1><%= Resource.Title %></h1>
    <div id="editFormWrapper">
        <% using (scope(Xhtml.Form(Resource).Method("post"))) { %>            
        <div id="contentTextAreaWrapper">
            <textarea name="content" cols="50" rows="20"><%= Resource.Content %></textarea>
        </div>
        <div id="saveWrapper">
            <input type="submit" value="Save" /> <a href="<%= Resource.CreateUri() %>">Cancel</a>
        </div>
        <% } %>
    </div>
</asp:Content>
