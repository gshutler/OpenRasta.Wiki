using System;
using NUnit.Framework;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;

namespace OpenRasta.Wiki.Specifications.Repository
{
    public class GettingAPageResourceFromAnEmptyDirectory : RepositorySpecification
    {
        PageResource resource;

        protected override void Given()
        {
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