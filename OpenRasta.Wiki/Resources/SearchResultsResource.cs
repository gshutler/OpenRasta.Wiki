using System;
using System.Collections.Generic;

namespace OpenRasta.Wiki.Resources
{
    public class SearchResultsResource
    {
        public string Query { get; set; }
        public IEnumerable<PageResource> PageResources { get; set; }
    }
}