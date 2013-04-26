define('paging', ['jquery', 'query-string'], function ($, qs) {
  var paging = {},
      firstPageButton = $('.first'),
      lastPageButton = $('.last'),
      nextPageButton = $('.next'),
      previousPageButton = $('.prev'),
      totalCount = parseInt($('span', '.paging:first').text(), 10),
      pageInfo = function () {
        var params = qs.getParameters();
        return {
          count: params.Count ? parseInt(params.Count, 10) : 25,
          page: params.Page ? parseInt(params.Page, 10) : 1
        };
      } (),
      querystring = '?Count=' + pageInfo.count + '&Page=';
  

  paging.goToPage = function(input) {
    var val = parseInt(input.val(), 10),
        inRange = val !== pageInfo.page && val <= totalCount && val > 0;

    window.location = inRange
      ? window.location = querystring + val
      : window.location = querystring + pageInfo.page;
  };

  paging.setPaging = function (currentPageInput) {
    firstPageButton.attr('href', querystring + '1');
    lastPageButton.attr('href', querystring + totalCount);
    if(currentPageInput) {
      currentPageInput.val(pageInfo.page);
    }

    if (pageInfo.page < totalCount) {
      nextPageButton.attr('href', querystring + (pageInfo.page + 1));
    }

    if (pageInfo.page !== 1) {
      previousPageButton.attr('href', querystring + (pageInfo.page - 1));
    }
  };

  paging.changeCountPerPage = function (count) {
    window.location = '?Count=' + count + '&Page=1';
  };


  return paging;
});