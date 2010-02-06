using System;
using NUnit.Framework;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;

namespace OpenRasta.Wiki.Specifications.Repository
{
    public class GettingAPageResource : RepositorySpecification
    {
        PageResource savedPage;
        PageResource retrievedPage;

        protected override void Given()
        {
            savedPage = new PageResource {Title = "Title", Content = "Content"};

            Subject<PageRepository>().Save(savedPage);
        }

        protected override void When()
        {
            retrievedPage = Subject<PageRepository>().Get("Title");
        }

        [Then]
        public void RetrievedPageHasSavedTitle()
        {
            Verify(retrievedPage.Title, Is.EqualTo(savedPage.Title));
        }

        [Then]
        public void RetrievedPageHasSavedContent()
        {
            Verify(retrievedPage.Content, Is.EqualTo(savedPage.Content));
        }
    }
}