define('js-loader', ['jquery'], function ($) {
  var loader = {}, scripts, source, $script;

  loader.load = function (html) {
      scripts = $(html).filter('script');
      scripts.each(function (i, script) {
        $script = $(script);
        source = $script.attr('src');
        if(source) {
          require([source]);
          html = html.replace($script[0].outerHTML, '');
        }
      });
    return html;
  };

  return loader;
});