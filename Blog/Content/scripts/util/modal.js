jQuery.fn.modal = function (key) {
  if (key) {
      $('.modal')[key]();
  }

  $('.modal').show();
};