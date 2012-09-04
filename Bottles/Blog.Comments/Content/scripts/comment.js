define('comment', ['jquery'], function ($) {
  $('form').bind('submit', function () {
    $.ajax({
      url: this.action,
      type:'POST',
      data: $(this).serialize(),
      success: function () {
        $('.submitcomment').text('Your comment has been submitted!');
      }
    });
    return false;
  });
});