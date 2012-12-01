/*
  expects globals:
  '/_content/scripts/util/pagedown/Markdown.Converter.js',
  '/_content/scripts/util/pagedown/Markdown.Sanitizer.js',
  '/_content/scripts/util/pagedown/Markdown.Editor.js'
*/
define('pagedown', [],
  function () {
    var pagedown = {},
        converter = Markdown.getSanitizingConverter();
    
    pagedown.createEditor = function () {
      var editor = new Markdown.Editor(converter);
      editor.run();
    };

    pagedown.convert = function(text) {
      var html = converter.makeHtml(text);

      return html;
    };

    return pagedown;
  });