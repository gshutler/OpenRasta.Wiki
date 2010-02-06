using System;
using NUnit.Framework;
using OpenRasta.Collections.Specialized;
using OpenRasta.Web;
using OpenRasta.Wiki.Handlers;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;
using Rhino.Mocks;

namespace OpenRasta.Wiki.Specifications.Page
{
    public class AlteringAPage : Specification
    {
        readonly PageResource resource = new PageResource();
        readonly Uri pageUri = new Uri("http://localhost/page/edited");
        OperationResult.SeeOther result;

        protected override void Given()
        {
            var baseUri = new Uri("http://localhost/");

            Dependency<ICommunicationContext>()
                .Stub(x => x.ApplicationBaseUri)
                .Return(baseUri);

            Dependency<IUriResolver>()
                .Stub(x => x.CreateUriFor(baseUri, typeof(PageResource), null, resource.ToNameValueCollection()))
                .Return(pageUri);
        }

        protected override void When()
        {
            result = Subject<PageHandler>().Post("title", "content");
        }

        [Then]
        public void ResourceSaved()
        {
            var savedPage = (PageResource) Dependency<IPageRepository>().GetArgumentsForCallsMadeOn(x => x.Save(null))[0][0];

            Verify(savedPage.Title, Is.EqualTo("title"));
            Verify(savedPage.Content, Is.EqualTo("content"));
        }

        [Then]
        public void RedirectedToResourceUri()
        {
            Verify(result.RedirectLocation, Is.EqualTo(pageUri));
        }
    }
}