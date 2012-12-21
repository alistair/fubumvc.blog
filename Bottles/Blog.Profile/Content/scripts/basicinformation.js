require(['jquery', 'messaging', 'validation'], function ($, messaging, validation) {
  var form = $('form', '.basicinformation');
  form.bind('submit', function () {
    validation.ajax.validate({
      url: this.action,
      type: 'POST',
      form: form,
      data: $(this).serialize(),
      success: function () {
        messaging.raiseSuccess(form, 'Your profile information has been successfully updated.');
      }
    });
    return false;
  });

  $('input[value=Cancel]').click(function () {
    window.location = window.location;
  });
});