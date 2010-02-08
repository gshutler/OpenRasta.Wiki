using System;
using NUnit.Framework;
using OpenRasta.Wiki.Handlers;
using OpenRasta.Wiki.Resources;

namespace OpenRasta.Wiki.Specifications.Search
{
    public class RetrievingThePageWithoutAQuery : Specification
    {
        SearchResultsResource result;

        protected override void Given()
        {
        }

        protected override void When()
        {
            result = Subject<SearchHandler>().Get();
        }

        [Then]
        public void NoPagesReturned()
        {
            Verify(result.PageResources, Is.Not.Null);
            Verify(result.PageResources, Is.Empty);
        }

        [Then]
        public void GivenQueryPassed()
        {
            Verify(result.Query, Is.EqualTo(""));
        }
    }
}