define('managecomments', ['jquery', 'query-string'], function ($, qs) {
  var countInput = $('input[name="count"]'),
      pageInfo = function () {
        var data = qs.getParameters();

        return {
          count: data.Count ? parseInt(data.Count, 10) : 25,
          page: data.Page ? parseInt(data.Page, 10) : 1
        };
      } (),
      setPaging = function () {
        $('.nextpage').attr('href', '?Count=' + pageInfo.count + '&Page=' + (pageInfo.page + 1));

        if (pageInfo.count !== 1) {
          $('.prevpage').attr('href', '?Count=' + pageInfo.count + '&Page=' + (pageInfo.page - 1));
        }

          $('.firstpage').attr('href', '?Count=' + pageInfo.count + '&Page=1');

        countInput.val(pageInfo.page);
      };

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

  setPaging();

  countInput.blur(function () {
    var val = parseInt(countInput.val(), 10);
    if (val !== pageInfo.count) {
      window.location = '?Count=' + pageInfo.count + '&Page=' + val;
    }
  });

});