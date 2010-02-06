using System;
using System.Linq;
using Lucene.Net.Index;
using NUnit.Framework;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;

namespace OpenRasta.Wiki.Specifications.Repository
{
    public class SavingANewPage : RepositorySpecification
    {
        PageResource resource;

        protected override void Given()
        {
            resource = new PageResource {Title = "Something", Content = "Description"};
        }

        protected override void When()
        {
            Subject<PageRepository>().Save(resource);
        }

        [Then]
        public void DocumentSavedToTheDirectory()
        {
            var document = GetDocument(new Term("Title", "Something"));

            Verify(document.Get("Title"), Is.EqualTo("Something"));
            Verify(document.Get("Content"), Is.EqualTo("Description"));
        }
    }
}