<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<HomeResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="Content" ID="content" runat="server">
    <div>
        <h1>Welcome to the OpenRasta wiki</h1>
        <p>
            To create a page goto "/{title}".        
        </p>
        <p>
            You can also 
            <a href="<%= typeof(SearchResultsResource).CreateUri() %>">search the wiki</a>
        </p>
        <p>
            This page isn't editable as this is a simple example. There's
            no authentication or anything either.
        </p>
    </div>
</asp:Content>
