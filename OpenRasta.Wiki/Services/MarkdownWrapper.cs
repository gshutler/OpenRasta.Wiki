using System;
using MarkdownSharp;

namespace OpenRasta.Wiki.Services
{
    public interface IMarkdown
    {
        string Transform(string content);
    }

    public class MarkdownWrapper : IMarkdown
    {
        readonly Markdown markdown;

        public MarkdownWrapper(Markdown markdown)
        {
            this.markdown = markdown;
        }

        public string Transform(string content)
        {
            return markdown.Transform(content);
        }
    }
}