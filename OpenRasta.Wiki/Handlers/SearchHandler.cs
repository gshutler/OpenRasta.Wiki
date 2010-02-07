using System;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;

namespace OpenRasta.Wiki.Handlers
{
    public class SearchHandler
    {
        readonly IPageRepository pageRepository;

        public SearchHandler(IPageRepository pageRepository)
        {
            this.pageRepository = pageRepository;
        }

        public SearchResultsResource Get(SearchResultsResource resource)
        {
            resource.PageResources = pageRepository.Query(resource.Query);

            return resource;
        }
    }
}