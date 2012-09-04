define('articles',['jquery', 'showdown', 'underscore'], function ($, sd, _) {
  var articles = $('section', 'article'),
      html;

  _.each(articles, function (article) {
    article = $(article);
    html = article.html().trim();
    article.html(sd.makeHtml(html));
  });
  
  $('pre').addClass('prettyprint');
  prettyPrint();

});