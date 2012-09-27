define('compose', ['jquery', 'underscore', 'showdown'], function ($, _, sd) {
  var form = $('form'),
      textarea = $('textarea[name=Body]'),
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
        previewBox.html(sd.makeHtml(textarea.val()));
        $('pre').addClass('prettyprint');
        prettyPrint();
        showPreview();
      }, 1000),
      setTitle = _.debounce(function () {
        previewHeader.text(titleInput.val());
        urlInput.val('/' + titleInput
            .val()
            .toLowerCase()
            .replace(/[\. ]/g, '-'));
        prettyPrint();
        showPreview();
      }, 1000),
      compose = function (prop, location) {
        var data = form.serialize();

        $.ajax({
          url: form.action,
          type: 'POST',
          data: data + prop,
          dataType: 'json',
          success: function (result) {
            window.location = result[location];
          }
        });
      };

  textarea.keydown(preview);

  $('input[value="Post Article"], input[value="Update"]').click(function () {
    compose(undefined, 'url');
  });

  $('input[value="Save Draft"], input[value="Archive"]').click(function () {
    compose("&IsDraft=true", 'manageUrl');
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