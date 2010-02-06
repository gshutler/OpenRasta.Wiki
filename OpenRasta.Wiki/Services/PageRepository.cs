using System;
using OpenRasta.Wiki.Resources;

namespace OpenRasta.Wiki.Services
{
    public interface IPageRepository
    {
        PageResource Get(string title);
        void Save(PageResource resource);
    }

    public class PageRepository : IPageRepository
    {
        public PageResource Get(string title)
        {
            return null;
        }

        public void Save(PageResource resource)
        {

        }
    }
}