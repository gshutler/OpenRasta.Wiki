using System;
using NUnit.Framework;
using OpenRasta.Wiki.Handlers;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;
using Rhino.Mocks;

namespace OpenRasta.Wiki.Specifications.Page
{
    public class DisplayingAPage : Specification
    {
        PageResource resource;
        readonly PageResource existingResource = new PageResource();

        protected override void Given()
        {
            Dependency<IPageRepository>()
                .Stub(x => x.Get("existingPage"))
                .Return(existingResource);
        }

        protected override void When()
        {
            resource = Subject<PageHandler>().Get("existingPage");
        }

        [Then]
        public void ExistingResourceIsRendered()
        {
            Verify(resource, Is.SameAs(existingResource));
        }
    }
}