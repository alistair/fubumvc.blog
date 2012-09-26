define('managecomments', ['jquery', 'query-string'], function ($, qs) {
  var countInput = $('input[name="count"]'),
      firstPageButton = $('.firstpage'),
      lastPageButton = $('.lastpage'),
      nextPageButton = $('.nextpage'),
      previousPageButton = $('.prevpage'),
      totalCount = parseInt($('label', '.paging:first').text(), 10),
      pageInfo = function () {
        var params = qs.getParameters();
        return {
          count: params.Count ? parseInt(params.Count, 10) : 25,
          page: params.Page ? parseInt(params.Page, 10) : 1
        };
      } (),
      querystring = '?Count=' + pageInfo.count + '&Page=',
      setPaging = function () {
        firstPageButton.attr('href', querystring + '1');
        lastPageButton.attr('href', querystring + totalCount);
        countInput.val(pageInfo.page);

        if (pageInfo.page < totalCount) {
          nextPageButton.attr('href', querystring + (pageInfo.page + 1));
        }

        if (pageInfo.page !== 1) {
          previousPageButton.attr('href', querystring + (pageInfo.page - 1));
        }
      },
      changeCommentsPerPage = function (count) {
        window.location = '?Count=' + count + '&Page=1';
      };

  $('.delete-comment').click(function () {
    var link = $(this);

    $.ajax({
      url: '/comments/manage',
      type: 'DELETE',
      data: { Id: link.data().id },
      dataType: 'json',
      success: function () {
        link.closest('tr').fadeOut('slow');
      }
    });
  });

  $('.25').click(function () { changeCommentsPerPage(25); });
  $('.50').click(function () { changeCommentsPerPage(50); });
  $('.100').click(function () { changeCommentsPerPage(100); });

  countInput.blur(function () {
    var val = parseInt(countInput.val(), 10),
      inRange = val !== pageInfo.count && val <= totalCount && val > 0;

    window.location = inRange
      ? window.location = querystring + val
      : window.location = querystring + pageInfo.page;
  });

  setPaging();
});