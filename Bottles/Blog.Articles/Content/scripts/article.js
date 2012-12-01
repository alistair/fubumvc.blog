﻿define('article', ['jquery', 'pagedown', 'pretty'], function ($, pagedown, pretty) {
  var article = $('section', 'article'),
      html = article.text().trim(),
      md = pagedown.convert(html);
  article.html(md);

  pretty.makePagePretty();
  pretty.makePrettyLineNumbersForPage();
});