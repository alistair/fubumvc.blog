require(['jquery'], function ($) {

  $.ajaxSetup({
    statusCode: {
      500: function (error) {
        if(window.location.pathname === '/') {
          $('.bootstrap-error').show();
        }
      } 
    }
  });
});