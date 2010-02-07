using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenRasta.Wiki.Handlers;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;
using Rhino.Mocks;

namespace OpenRasta.Wiki.Specifications.Search
{
    public class SubmittingAValidQuery : Specification
    {
        SearchResultsResource result;
        readonly IEnumerable<PageResource> pageResources = new List<PageResource>();
        SearchResultsResource resource;

        protected override void Given()
        {
            Dependency<IPageRepository>()
                .Stub(x => x.Query("query"))
                .Return(pageResources);

            resource = new SearchResultsResource {Query = "query"};
        }

        protected override void When()
        {
            result = Subject<SearchHandler>().Get(resource);
        }

        [Then]
        public void MatchingPagesReturned()
        {
            Verify(result.PageResources, Is.SameAs(pageResources));
        }

        [Then]
        public void GivenQueryPassed()
        {
            Verify(result, Is.SameAs(resource));
            Verify(result.Query, Is.EqualTo("query"));
        }
    }
}