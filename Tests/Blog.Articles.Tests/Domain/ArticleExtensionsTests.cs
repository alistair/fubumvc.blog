using System.Collections.Generic;
using System.Linq;
using Blog.Articles.Domain;
using SharpTestsEx;
using Xunit;

namespace Blog.Articles.Tests.Domain
{
    public class ArticleExtensionsTests
    {
        private readonly Article[] _articles;

        public ArticleExtensionsTests()
        {
             _articles = new[]
             {
                 new Article
                 {
                     IsPublished = false
                 },
                 new Article
                 {
                     IsPublished = true
                 }
             };
        }

         [Fact]
         public void FilteryByPublished_articles_returns_all_articles_when_filter_not_set()
         {
             var query = new EnumerableQuery<Article>(_articles).FilteryByPublished(null);
             query.Count().Should().Be(2);
         }

         [Fact]
         public void FilteryByPublished_articles_returns_draft_articles_when_filter_by_published_true()
         {
             var query = new EnumerableQuery<Article>(_articles).FilteryByPublished(true);
             query.Count().Should().Be(1);
             query.Each(x => x.IsPublished.Should().Be.False());
         }

         [Fact]
         public void FilteryByPublished_articles_returns_published_articles_when_filter_by_published_false()
         {
             var query = new EnumerableQuery<Article>(_articles).FilteryByPublished(false);
             query.Count().Should().Be(1);
             query.Each(x => x.IsPublished.Should().Be.True());
         }
    }
}