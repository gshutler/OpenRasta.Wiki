using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenRasta.Wiki.Resources
{
    public class SearchResultsResource
    {
        public SearchResultsResource()
        {
            Query = "";
            PageResources = Enumerable.Empty<PageResource>();
        }

        public string Query { get; set; }
        public IEnumerable<PageResource> PageResources { get; set; }
    }
}