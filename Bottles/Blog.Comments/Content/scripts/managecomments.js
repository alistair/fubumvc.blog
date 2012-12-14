require(['jquery', 'paging', 'messaging'], function ($, paging, messaging) {
  var countInput = $('input[name="count"]');

  $('.delete-comment').click(function () {
    var link = $(this);

    $.ajax({
      url: '/comments/manage',
      type: 'DELETE',
      data: { Id: link.data().id },
      dataType: 'json',
      success: function () {
        link.closest('tr').fadeOut('slow');
        messaging.raiseRemove($('.managecommentsfilters:first').parent(), 'Comment has been successfully deleted.');
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