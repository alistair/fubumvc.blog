define('managearticles', ['jquery', 'paging', 'messaging'], function ($, paging, messaging) {
  var countInput = $('input[name="count"]');

  $('.delete-article').click(function () {
    var link = $(this),
        id = link.data().id,
        proceedWithDeletion = confirm('Are you sure you want to delete (' + id + '). \r\nThis action cannot be undone.');

    if (!proceedWithDeletion) {
      return false;
    }

    $.ajax({
      url: '/articles/manage',
      type: 'DELETE',
      data: { Id: id },
      dataType: 'json',
      success: function () {
        messaging.raiseRemove($('.managearticlefilters:first').parent(), 'Article (' + id + '), has been successfully deleted.');
        link.closest('tr').fadeOut('slow');
      }
    });
  });

  $('.25, .50, .100').click(function () {
    var count = $(this);
    paging.changeCountPerPage(count.text());
  });


  $('.filter').change(function () {
    var val = $(this).val();

    window.location ='http://localhost:52680/articles/manage?ShowDraft=' + val;
  });

  countInput.blur(function () {
    paging.goToPage($(this));
  });

  paging.setPaging(countInput);
});