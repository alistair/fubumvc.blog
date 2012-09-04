define('module-loader', ['jquery', 'js-loader', 'domReady'], function ($, jL, domReady) {
  var loader = {},
      page = $('html'),
      attr = 'module',
      module;

  loader.load = function () {
    $('[' + attr + ']').each(function () {
      module = $(this);
      $.ajax({
        url: module.attr(attr),
        async: false,
        success: function (moduleHtml) {
          module.prepend(jL.load(moduleHtml));
        }
      });
    });
    domReady(function () { page.show(); });
  };

  return loader;
});