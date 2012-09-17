define('managecomments', ['jquery'], function ($) {
  $('.delete-comment').click(function () {
    var link = $(this),
      data = link.data();
    $.ajax({
      url: '/comments/manage',
      type: 'DELETE',
      data: { Id: data.id },
      dataType: 'json',
      success: function () {
        link.closest('tr').remove();
      }
    });
  });
});