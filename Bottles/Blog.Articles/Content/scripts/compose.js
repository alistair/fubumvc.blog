require(['jquery', 'underscore', 'pagedown', 'pretty', 'validation', 'textarea-selection'], function ($, _, pagedown, pretty, validation, textareaSelection) {
    var form = $('form'),
      textarea = $('[name="Body"]'),
      titleInput = $('input[name=Title]'),
      urlInput = $('input[name=Id]'),
      previewHeader = $('#preview h2'),
      preview = _.debounce(function () {
          pretty.makePagePretty();
          pretty.makePrettyLineNumbersForPage();
      }, 500),
      setTitle = _.debounce(function () {
          previewHeader.text(titleInput.val());
          urlInput.val('/' + titleInput
            .val()
            .toLowerCase()
            .replace(/[\.\\\/\?\!\'\"]/g, '')
            .replace(/[ ]/g, '-'));
          prettyPrint();
          previewHeader.toggle(titleInput.val().length !== 0);
          $('#preview').toggle(titleInput.val().length !== 0 ||
          textarea.val().length !== 0);
      }, 1000),
      compose = function (location, prop) {
          var data = form.serialize();

          validation.ajax.validate({
              url: form.action,
              type: 'POST',
              form: form,
              data: prop ? data + prop : data,
              dataType: 'json',
              success: function (result) {
                  window.location = result[location];
              }
          });
      };
    pagedown.createEditor();
    textarea.keydown(preview);

    $('input[value="Post Article"], input[value="Update"]').click(function () {
        compose('url');
    });

    $('input[value="Save Draft"], input[value="Archive"]').click(function () {
        compose('manageUrl', "&IsDraft=true");
    });

    preview();

    if (urlInput.val().length === 0) {
        titleInput.keydown(setTitle);
        setTitle();
    } else {
        urlInput.attr('disabled', 'disabled');
        urlInput.val('/' + urlInput.val());
    }

    $('input[value=Cancel]').click(function () {
        window.location = '/articles/manage';
    });

});