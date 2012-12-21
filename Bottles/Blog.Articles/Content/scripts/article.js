require(['jquery', 'pagedown', 'pretty'], function ($, pagedown, pretty) {
  var article = $('section', 'article'),
      md = pagedown.convert(article.text());

  article.html(md);

  pretty.makePagePretty();
  pretty.makePrettyLineNumbersForPage();
});