define('compose', ['jquery', 'underscore', 'pagedown', 'pretty', 'validation', 'textarea-selection'], function ($, _, pagedown, pretty, validation, textareaSelection) {
    var form = $('form'),
      textAreaSelector = '[name="Body"]',
      textarea = $(textAreaSelector),
      titleInput = $('input[name=Title]'),
      urlInput = $('input[name=Id]'),
      previewHeader = $('#preview h2'),
      previewBox = $('#preview section'),
      showPreview = function () {
          previewHeader.toggle(titleInput.val().length !== 0);
          $('#preview').toggle(titleInput.val().length !== 0 ||
          textarea.val().length !== 0);
      },
      preview = _.debounce(function () {
          //previewBox.html(sd.makeHtml(textarea.val()));
          pretty.makePagePretty();
          pretty.makePrettyLineNumbersForPage();
          showPreview();
      }, 500),
      setTitle = _.debounce(function () {
          previewHeader.text(titleInput.val());
          urlInput.val('/' + titleInput
            .val()
            .toLowerCase()
            .replace(/[\.\\\/\?\!\'\"]/g, '')
            .replace(/[ ]/g, '-'));
          prettyPrint();
          showPreview();
      }, 1000),
      compose = function (prop, location) {
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
        compose(undefined, 'url');
    });

    $('input[value="Save Draft"], input[value="Archive"]').click(function () {
        compose("&IsDraft=true", 'manageUrl');
    });

    $('[title="Bold"]').click(function () {
        var bold = '**';
        textareaSelection.wrap(textAreaSelector, bold, bold);
        preview();
    });

    $('[title="Italic"]').click(function () {
        var italic = '_';
        textareaSelection.wrap(textAreaSelector, italic, italic);
        preview();
    });

    preview();
    if (urlInput.val().length === 0) {
        titleInput.keydown(setTitle);
        setTitle();
    } else {
        urlInput.attr('disabled', 'disabled');
        urlInput.val('/' + urlInput.val());
    }

    $('input[value=Cancel]').bind('click', function () {
        window.location = '/articles/manage';
    });

});