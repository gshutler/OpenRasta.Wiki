using System;
using System.Collections.Generic;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using OpenRasta.Wiki.Resources;

namespace OpenRasta.Wiki.Services
{
    public interface IPageRepository
    {
        PageResource Get(string title);
        void Save(PageResource resource);
        IEnumerable<PageResource> Query(string query);
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

            if (hits.Length() == 0)
            {
                searcher.Close();
                return null;
            }

            var document =  hits.Doc(0);
            searcher.Close();

            return CreatePageResource(document);
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

        public IEnumerable<PageResource> Query(string queryString)
        {
            var combinedQuery = GenerateCombinedQuery(queryString);

            var searcher = new IndexSearcher(directory);

            var hits = searcher.Search(combinedQuery);

            for (var doc = 0; doc < hits.Length(); doc++)
            {
                yield return CreatePageResource(hits.Doc(doc));
            }

            searcher.Close();
        }

        Query GenerateCombinedQuery(string queryString)
        {
            var titleQuery = GenerateQuery(queryString, "Title");
            var contentQuery = GenerateQuery(queryString, "Content"); ;

            return titleQuery.Combine(new[] {contentQuery});
        }

        Query GenerateQuery(string queryString, string field)
        {
            var parser = new QueryParser(field, analyzer);
            return parser.Parse(queryString);
        }

        static Document CreateDocument(PageResource resource)
        {
            var document = new Document();

            document.Add(new Field("Title", resource.Title, Field.Store.YES, Field.Index.UN_TOKENIZED));
            document.Add(new Field("Content", resource.Content, Field.Store.YES, Field.Index.TOKENIZED));
            document.Add(new Field("TransformedContent", resource.TransformedContent, Field.Store.YES, Field.Index.NO));

            return document;
        }

        static PageResource CreatePageResource(Document document)
        {
            return new PageResource
                       {
                           Title = document.Get("Title"), 
                           Content = document.Get("Content"),
                           TransformedContent = document.Get("TransformedContent")
                       };
        }

        bool IndexEmpty()
        {
            return !IndexReader.IndexExists(directory);
        }
    }
}