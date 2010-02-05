using System;

namespace OpenRasta.Wiki.Resources
{
    public class PageResource
    {
        public const string DefaultContent = "This page doesn't exist yet. Visit /page/{title}/edit/ to create it.";

        public string Title { get; set; }
        public string Content { get; set; }
    }
}