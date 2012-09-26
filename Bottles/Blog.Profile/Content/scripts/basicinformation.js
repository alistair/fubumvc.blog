define('basicinformation', ['jquery', 'messaging'], function ($, messaging) {
  var form = $('form', '.basicinformation');
  form.bind('submit', function () {
    $.ajax({
      url: this.action,
      type: 'POST',
      data: $(this).serialize(),
      success: function () {
        messaging.raiseSuccess(form, 'Your profile information has been successfully updated.');
      }
    });
    return false;
  });

  $('input[value=Cancel]').bind('click', function () {
    window.location = window.location;
  });
});