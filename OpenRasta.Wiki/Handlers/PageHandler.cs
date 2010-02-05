using System;
using OpenRasta.Wiki.Resources;

namespace OpenRasta.Wiki.Handlers
{
    public class PageHandler
    {
        public PageResource Get(string title)
        {
            return new PageResource {Title = title, Content = PageResource.DefaultContent};
        }
    }
}