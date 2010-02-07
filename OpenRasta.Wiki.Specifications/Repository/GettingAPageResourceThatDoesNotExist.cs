using System;
using NUnit.Framework;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;

namespace OpenRasta.Wiki.Specifications.Repository
{
    public class GettingAPageResourceThatDoesNotExist : RepositorySpecification
    {
        PageResource resource;

        protected override void Given()
        {
            var page = new PageResource
                           {
                               Title = "Unrelated", 
                               Content = "Content",
                               TransformedContent = "Transformed content"
                           };

            Subject<PageRepository>().Save(page);
        }

        protected override void When()
        {
            resource = Subject<PageRepository>().Get("Something");
        }

        [Then]
        public void ResourceIsNull()
        {
            Verify(resource, Is.Null);
        }
    }
}