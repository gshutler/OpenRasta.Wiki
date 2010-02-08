#region License

/* Authors:
 *      Sebastien Lambla (seb@serialseb.com)
 * Copyright:
 *      (C) 2007-2009 Caffeine IT & naughtyProd Ltd (http://www.caffeine-it.com)
 * License:
 *      This file is distributed under the terms of the MIT License found at the end of this file.
 */

#endregion

using System;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Store;
using MarkdownSharp;
using OpenRasta.Configuration;
using OpenRasta.DI;
using OpenRasta.Wiki.Handlers;
using OpenRasta.Wiki.Resources;
using OpenRasta.Wiki.Services;
using Directory=Lucene.Net.Store.Directory;

namespace OpenRasta.Wiki
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Uses.Resolver.AddDependencyInstance(typeof(Markdown), new Markdown(), DependencyLifetime.Singleton);
                ResourceSpace.Uses.CustomDependency<IMarkdown, MarkdownWrapper>(DependencyLifetime.Singleton);

                ResourceSpace.Uses.Resolver.AddDependencyInstance(typeof(Directory), FileDirectory(), DependencyLifetime.Singleton);
                ResourceSpace.Uses.CustomDependency<Analyzer, StandardAnalyzer>(DependencyLifetime.Singleton);
                ResourceSpace.Uses.CustomDependency<IPageRepository, PageRepository>(DependencyLifetime.Transient);

                ResourceSpace.Has.ResourcesOfType<HomeResource>()
                    .AtUri("/home")
                    .And.AtUri("/")
                    .HandledBy<HomeHandler>()
                    .RenderedByAspx("~/Views/HomeView.aspx");

                ResourceSpace.Has.ResourcesOfType<NewPageResource>()
                    .WithoutUri
                    .RenderedByAspx("~/Views/NewPageView.aspx");

                ResourceSpace.Has.ResourcesOfType<PageResource>()
                    .AtUri("/{title}")
                    .And.AtUri("/{title}/edit").Named("edit")
                    .HandledBy<PageHandler>()
                    .RenderedByAspx(new
                                        {
                                            index = "~/Views/PageView.aspx",
                                            edit = "~/Views/PageEditView.aspx"
                                        });

                ResourceSpace.Has.ResourcesOfType<SearchResultsResource>()
                    .AtUri("/search")
                    .And.AtUri("/search?q={query}")
                    .HandledBy<SearchHandler>()
                    .RenderedByAspx("~/Views/SearchResultsView.aspx");
            }
        }

        static FSDirectory FileDirectory()
        {
            var appDataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            var luceneDirectory = Path.Combine(appDataPath, "lucene");

            if (System.IO.Directory.Exists(luceneDirectory))
            {
                return FSDirectory.GetDirectory(luceneDirectory);
            }

            System.IO.Directory.CreateDirectory(luceneDirectory);
            return FSDirectory.GetDirectory(luceneDirectory, true);
        }
    }
}

#region Full license

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#endregion