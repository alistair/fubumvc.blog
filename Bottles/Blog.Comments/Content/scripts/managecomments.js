define('managecomments', ['jquery', 'query-string'], function ($, qs) {
  var countInput = $('input[name="count"]'),
      totalCount = parseInt($('label','.paging:first').text(), 10),
      pageInfo = function () {
        var data = qs.getParameters();

        return {
          count: data.Count ? parseInt(data.Count, 10) : 25,
          page: data.Page ? parseInt(data.Page, 10) : 1
        };
      } (),
      setPaging = function (newCount) {
        var count = newCount || pageInfo.count,
          initialString = '?Count=' + count + '&Page=';

        $('.firstpage').attr('href', initialString + '1');
        $('.lastpage').attr('href', initialString + totalCount);
        countInput.val(pageInfo.page);

        if(pageInfo.page < totalCount) {
          $('.nextpage').attr('href',  initialString + (pageInfo.page + 1));
        }

        if (pageInfo.page !== 1) {
          $('.prevpage').attr('href', initialString + (pageInfo.page - 1));
        }
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
    if (val !== pageInfo.count && val <= totalCount && val > 0) {
      window.location = '?Count=' + pageInfo.count + '&Page=' + val;
    } else {
      window.location = '?Count=' + pageInfo.count + '&Page=' + pageInfo.page;
    }
  });

});