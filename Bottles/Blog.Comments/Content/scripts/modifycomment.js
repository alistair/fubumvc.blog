require(['jquery', 'messaging', 'validation'], function ($, messaging, validation) {
  var form = $('.modifycomment');
  form.bind('submit', function () {
    validation.ajax.validate({
      url: this.action,
      type: 'POST',
      form: form,
      data: $(this).serialize(),
      success: function () {
        messaging.raiseSuccess($('.modifycomment'), 'Your comment has been successfully updated.');
      }
    });
    return false;
  });

  $('input[value=Cancel]').bind('click', function () {
    window.location = '/comments/manage';
  });
});