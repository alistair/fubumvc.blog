define('modifycomment', ['jquery'], function ($) {
  $('.modifycomment').bind('submit', function () {
    $.ajax({
      url: this.action,
      type:'POST',
      data: $(this).serialize(),
      success: function () {
      }
    });
    return false;
  });
});