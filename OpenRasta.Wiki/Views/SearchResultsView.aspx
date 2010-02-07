<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<SearchResultsResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <div>
        <h1>Search</h1>
        <p>
            <% using(scope(Xhtml.Form<SearchResultsResource>().Method("get"))) { %>
                <input type="text" name="q" value="<%= Resource.Query %>" />
                <input type="submit" value="Search" />
            <% } %>
        </p>
        <ol class="searchResults">
        <% foreach (var page in Resource.PageResources) { %>
            <li><a href="<%= page.CreateUri() %>"><%= page.Title %></a></li>
        <% } %>
        </ol>
    </div>
</asp:Content>
