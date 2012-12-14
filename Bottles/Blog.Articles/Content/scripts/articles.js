require(['jquery', 'pagedown', 'underscore', 'pretty'], function ($, pagedown, _, pretty) {
  var articles = $('section', 'article');

  _.each(articles, function (article) {
    article = $(article);

    article.html(pagedown.convert(article.html()));
  });

  pretty.makePagePretty();
  pretty.makePrettyLineNumbersForPage();

});