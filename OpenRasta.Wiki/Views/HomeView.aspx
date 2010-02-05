<%@ Page Language="C#" Inherits="OpenRasta.Codecs.WebForms.ResourceView<HomeResource>" MasterPageFile="~/Views/HomeView.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
    <div>
        <p>
            Welcome to the OpenRasta wiki. To create a page goto "/page/{title}".        
        </p>
        <p>
            This page isn't editable as this is a simple example. There's
            no authentication or anything, but there should eventually be
            full text search which will be awesome!
        </p>
    </div>
</asp:Content>
