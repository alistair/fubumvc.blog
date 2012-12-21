require(['jquery', 'pagedown', 'pretty'], function ($, pagedown, pretty) {

  $('section', 'article').each(function () {
    var article = $(this);

    article.html(pagedown.convert(article.html()));
  });

  pretty.makePagePretty();
  pretty.makePrettyLineNumbersForPage();

});