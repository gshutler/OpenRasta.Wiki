using System;
using NUnit.Framework;
using OpenRasta.Wiki.Handlers;
using OpenRasta.Wiki.Resources;

namespace OpenRasta.Wiki.Specifications.Page
{
    public class DisplayingAPageThatDoesNotExist : Specification
    {
        PageResource resource;

        protected override void Given()
        {
        }

        protected override void When()
        {
            resource = Subject<PageHandler>().Get("newTitle");
        }

        [Then]
        public void ResourceHasGivenTitle()
        {
            Verify(resource.Title, Is.EqualTo("newTitle"));
        }

        [Then]
        public void ResourceHasDefaultContent()
        {
            Verify(resource.Content, Is.EqualTo(PageResource.DefaultContent));
        }
    }
}