using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;

namespace OpenRasta.Wiki.Specifications.Repository
{
    public class SearchingPageResources : RepositorySpecification
    {
        IEnumerable<PageResource> results;

        protected override void Given()
        {
            SavePageResource("Forest", "Football");
            SavePageResource("Derby", "Football");
            SavePageResource("Coventry", "Football");
            SavePageResource("South Africa", "Country");
        }

        protected override void When()
        {
            results = Subject<PageRepository>().Query("Football");
        }

        [Then]
        public void ThreePagesReturned()
        {
            Verify(results.Count(), Is.EqualTo(3));
        }
    }
}