using System;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
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
        readonly Directory directory;
        readonly Analyzer analyzer;

        public PageRepository(Directory directory, Analyzer analyzer)
        {
            this.directory = directory;
            this.analyzer = analyzer;
        }

        public PageResource Get(string title)
        {
            return null;
        }

        public void Save(PageResource resource)
        {
            var writer = new IndexWriter(directory, analyzer);
            var document = new Document();

            document.Add(new Field("Title", resource.Title, Field.Store.YES, Field.Index.UN_TOKENIZED));
            document.Add(new Field("Content", resource.Content, Field.Store.YES, Field.Index.TOKENIZED));

            writer.AddDocument(document);
            writer.Flush();
        }
    }
}