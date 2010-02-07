<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<NewPageResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <h1><%= Resource.Title %></h1>
    <div id="editFormWrapper">
        <% var pageResource = new PageResource { Title = Resource.Title }; %>
        <% using (scope(Xhtml.Form(pageResource).Method("post")))
           { %>            
        <div id="contentTextAreaWrapper">
            <textarea name="content" cols="50" rows="20">This page does not exist yet.</textarea>
        </div>
        <div id="saveWrapper">
            <input type="submit" value="Save" />
        </div>
        <% } %>
    </div>
</asp:Content>
