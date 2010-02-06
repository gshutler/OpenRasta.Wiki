using System;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
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
            if (IndexEmpty()) return null;

            var query = new TermQuery(new Term("Title", title));
            var searcher = new IndexSearcher(directory);
            var hits = searcher.Search(query);

            var document =  hits.Doc(0);
            searcher.Close();

            return new PageResource {Title = document.Get("Title"), Content = document.Get("Content")};
        }

        bool IndexEmpty()
        {
            return !IndexReader.IndexExists(directory);
        }

        public void Save(PageResource resource)
        {
            var writer = new IndexWriter(directory, analyzer);
            var document = CreateDocument(resource);

            writer.DeleteDocuments(new Term("Title", resource.Title));
            writer.AddDocument(document);

            writer.Flush();
            writer.Close();
        }

        static Document CreateDocument(PageResource resource)
        {
            var document = new Document();

            document.Add(new Field("Title", resource.Title, Field.Store.YES, Field.Index.UN_TOKENIZED));
            document.Add(new Field("Content", resource.Content, Field.Store.YES, Field.Index.TOKENIZED));

            return document;
        }
    }
}