using System;

namespace OpenRasta.Wiki.Resources
{
    public class PageResource
    {
        public const string DefaultContent = "This page doesn't exist yet.";

        public string Title { get; set; }
        public string Content { get; set; }
    }
}