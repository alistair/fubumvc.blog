require(['jquery', 'messaging', 'validation'], function ($, messaging, validation) {
  var form = $('form');
  form.bind('submit', function () {
    validation.ajax.validate({
      url: this.action,
      type: 'POST',
      form: form,
      data: $(this).serialize(),
      success: function () {
        messaging.raiseSuccess(form, 'Your comment has been submitted!');
      }
    });
    return false;
  });
});