using System;
using Lucene.Net.Index;
using NUnit.Framework;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;

namespace OpenRasta.Wiki.Specifications.Repository
{
    public class SavingAPageWithAnExistingDocument : RepositorySpecification
    {
        PageResource newPageResource;

        protected override void Given()
        {
            var oldPageResource = new PageResource
                                      {
                                          Title = "Something", 
                                          Content = "Old Content",
                                          TransformedContent = "Transformed old content"
                                      };

            newPageResource = new PageResource
                                  {
                                      Title = "Something", 
                                      Content = "New Content",
                                      TransformedContent = "Transformed new content"
                                  };

            Subject<PageRepository>().Save(oldPageResource);
        }

        protected override void When()
        {
            Subject<PageRepository>().Save(newPageResource);
        }

        [Then]
        public void OneDocumentWithNewContent()
        {
            var document = GetDocument(new Term("Title", "Something"));

            Verify(document.Get("Title"), Is.EqualTo("Something"));
            Verify(document.Get("Content"), Is.EqualTo("New Content"));
            Verify(document.Get("TransformedContent"), Is.EqualTo("Transformed new content"));
        }
    }
}