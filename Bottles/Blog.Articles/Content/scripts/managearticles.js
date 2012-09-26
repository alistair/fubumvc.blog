define('managearticles', ['jquery', 'paging', 'messaging'], function ($, paging, messaging) {
  var countInput = $('input[name="count"]');

  $('.delete-article').click(function () {
    var link = $(this),
        id = link.data().id;
    $.ajax({
      url: '/articles/manage',
      type: 'DELETE',
      data: { Id: id },
      dataType: 'json',
      success: function () {
        link.closest('tr').fadeOut('slow');
        messaging.raiseRemove($('.managearticlefilters:first').parent(), 'Article ('+ id +') has been successfully deleted.');
      }
    });
  });

  $('.25, .50, .100').click(function () {
    var count = $(this);
    paging.changeCountPerPage(count.text());
  });

  countInput.blur(function () {
    paging.goToPage($(this));
  });

  paging.setPaging(countInput);
});