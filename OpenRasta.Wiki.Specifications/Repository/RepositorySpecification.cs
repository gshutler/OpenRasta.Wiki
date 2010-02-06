using System;
using System.Collections.Generic;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;

namespace OpenRasta.Wiki.Specifications.Repository
{
    public abstract class RepositorySpecification : Specification
    {
        protected Directory directory;

        protected override void CommonContext()
        {
            InjectDependency(directory = new RAMDirectory());
            InjectDependency<Analyzer>(new StandardAnalyzer());
        }

        protected override void TidyUp()
        {
            directory = null;
        }

        protected Document GetDocument(Term term)
        {
            var query = new TermQuery(term);
            var searcher = new IndexSearcher(directory);
            var hits = searcher.Search(query);

            if (hits.Length() != 1)
            {
                throw new Exception("Expected 1 document but found " + hits.Length());
            }

            return hits.Doc(0);
        }
    }
}