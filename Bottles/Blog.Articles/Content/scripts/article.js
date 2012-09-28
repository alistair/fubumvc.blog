define('article', ['jquery', 'showdown', 'pretty'], function ($, sd, pretty) {
  var article = $('section', 'article'),
      html = article.text().trim(),
      md = sd.makeHtml(html);
  article.html(md);

  pretty.makePagePretty();
  pretty.makePrettyLineNumbersForPage();
});