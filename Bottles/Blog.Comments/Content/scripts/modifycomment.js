define('modifycomment', ['jquery', 'messaging'], function ($, messaging) {
  $('.modifycomment').bind('submit', function () {
    $.ajax({
      url: this.action,
      type: 'POST',
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