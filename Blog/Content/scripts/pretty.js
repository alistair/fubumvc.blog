define('pretty', ['jquery', 'underscore'], function ($, _) {
  var pretty = {};

  pretty.makePagePretty = function () {
    pretty.makeElementPretty($('pre'));
  };

  pretty.makeElementPretty = function (element) {
    element
      .addClass('prettyprint linenums');
    prettyPrint();
  };


  //TODO: this needs some serious cleanup:
  pretty.makePrettyLineNumbersForPage = function () {
    var code = $('.prettyprint'),
      numberClass = 'prettyprintnumbers';
    _.each(code, function (s) {
      var i = 0,
          snippet = $(s),
          lines = $('li', snippet),
          lineCount = lines.length,
          numbers = $('<table></table>');

      for (i; i < lineCount; i++) {
        var start = '<tr><td class="num">' + (i + 1) + '.</td>',
          end = '</tr>';
        if (i === 0) {
          start += '<td class="code" rowspan="' + lineCount + '"><pre>';
          start += snippet.html();
          start += '</pre></td>';
        }
        numbers.append(start + end);
      }

      $('ol', snippet).remove();

      snippet.addClass(numberClass);
      snippet.html(numbers);

      $('code:empty').text(' ');
    });
  };

  return pretty;

});