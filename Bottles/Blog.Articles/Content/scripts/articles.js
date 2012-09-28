define('articles',['jquery', 'showdown', 'underscore', 'pretty'], function ($, sd, _, pretty) {
  var articles = $('section', 'article'),
      html;

  _.each(articles, function (article) {
    article = $(article);
    html = article.html().trim();
    article.html(sd.makeHtml(html));
  });
  
  pretty.makePagePretty();
  pretty.makePrettyLineNumbersForPage();

});