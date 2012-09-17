define('managearticles', ['jquery'], function ($) {
  $('.delete-article').click(function () {
    var link = $(this),
      data = link.data();
    $.ajax({
      url: '/articles/manage',
      type: 'DELETE',
      data: { Id: data.id },
      dataType: 'json',
      success: function () {
        link.closest('tr').remove();
      }
    });
  });
});