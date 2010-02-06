using System;
using OpenRasta.Collections.Specialized;
using OpenRasta.Web;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;

namespace OpenRasta.Wiki.Handlers
{
    public class PageHandler
    {
        readonly IPageRepository pageRepository;
        readonly ICommunicationContext context;
        readonly IUriResolver uriResolver;

        public PageHandler(IPageRepository pageRepository, ICommunicationContext context, IUriResolver uriResolver)
        {
            this.pageRepository = pageRepository;
            this.context = context;
            this.uriResolver = uriResolver;
        }

        public PageResource Get(string title)
        {
            return pageRepository.Get(title) ?? DefaultPageResource(title);
        }

        static PageResource DefaultPageResource(string title)
        {
            return new PageResource { Title = title, Content = PageResource.DefaultContent };
        }

        public OperationResult.SeeOther Post(PageResource resource)
        {
            pageRepository.Save(resource);

            var redirectLocation = uriResolver.CreateUriFor(context.ApplicationBaseUri, 
                typeof (PageResource), null, resource.ToNameValueCollection());
            
            return new OperationResult.SeeOther
                       {
                           RedirectLocation = redirectLocation
                       };
        }
    }
}