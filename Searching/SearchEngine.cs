
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using Lucene.Net.Util;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers.Classic;

using ProjectConker.Models;

namespace ProjectConker.Searching
{
    public class SearchEngine
    {

        string indexPath;
        readonly ConkerDbContext _dbContext;
        IndexWriter writer;
        FSDirectory directory;


        public SearchEngine(ConkerDbContext dbContext)
        {
            indexPath = @"./Searching/SearchIndices";
            _dbContext = dbContext;
            
            directory = FSDirectory.Open(new DirectoryInfo(indexPath));            
        }


        public async Task addDocuments()
        {
            await _dbContext.Roadmap.ForEachAsync(roadmap =>
            {
                addDocument(roadmap);
            });

            writer.Commit();
        }

        public void addDocument(Roadmap roadmap)
        {

            if(writer == null)
            {
                var analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48);
                IndexWriterConfig conf = new IndexWriterConfig(LuceneVersion.LUCENE_48, analyzer);
                writer = new IndexWriter(directory, conf);
            }
           

            Document doc = new Document();

            string title = roadmap.Title;
            string intro = roadmap.Summary;
            
            var roadmapTags = _dbContext.Entry(roadmap)
                            .Collection(r => r.RoadmapTag)
                            .Query().Select(roadmapTag => roadmapTag.Tag);

            var tags = String.Join(" ", roadmapTags);

            var idField = new StringField("Id", roadmap.RoadmapId.ToString(), Field.Store.YES);

            doc.Add(idField);


            var titleField = new TextField("Title", title, Field.Store.YES);
            titleField.Boost = 3;

            doc.Add(titleField);

            var introField = new TextField("Intro", intro, Field.Store.YES);
            introField.Boost = 4;

            doc.Add(introField);

            var tagField = new TextField("Tags", tags, Field.Store.YES);
            tagField.Boost = 1;

            doc.Add(tagField);

            foreach (var tag in roadmapTags)
            {
                var tokenizedTagField = new StringField("TokenizedTags", tag.TagName, Field.Store.YES);
                doc.Add(tokenizedTagField);
            }

            writer.AddDocument(doc);
            writer.Commit();
        }

        IEnumerable<Document> findMatchingDocs(Query query, int numberOfDocs)
        {
            IndexReader reader = DirectoryReader.Open(directory);
            IndexSearcher searcher = new IndexSearcher(reader);

            TopDocs topDocs = searcher.Search(query, numberOfDocs);
        

            //reader.close();
            return topDocs.ScoreDocs.Select(result => searcher.Doc(result.Doc));
        }


        List<SearchResult> getSearchResults(IEnumerable<Document> docs)
        {
            List<SearchResult> results = new List<SearchResult>();

            foreach (var doc in docs)
            {
                string title = doc.Get("Title");
                string authorName = "MatriXcel";
                string summary = doc.Get("Intro");

                var tags = doc.GetFields("TokenizedTags").Select(field => field.GetStringValue());

                SearchResult result = new SearchResult
                {
                    Title = title,
                    Tags = tags,
                    AuthorName = authorName,
                    Summary = summary

                };

                results.Add(result);
            }

            return results;
        }


        public IEnumerable<SearchResult> search(string[] tags)
        {
            BooleanQuery query = new BooleanQuery();

            foreach (var tag in tags)
            {
                TermQuery tq = new TermQuery(new Term("TokenizedTags", tag));
                query.Add(tq, Occur.SHOULD);
            }

            var docs = findMatchingDocs(query, 10);

            return getSearchResults(docs);
        }


    }
}