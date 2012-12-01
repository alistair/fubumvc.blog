define('articles',['jquery', 'pagedown', 'underscore', 'pretty'], function ($, pagedown, _, pretty) {
  var articles = $('section', 'article'),
      html;

  _.each(articles, function (article) {
    article = $(article);
    html = article.html().trim();
    article.html(pagedown.convert(html));
  });
  
  pretty.makePagePretty();
  pretty.makePrettyLineNumbersForPage();

});