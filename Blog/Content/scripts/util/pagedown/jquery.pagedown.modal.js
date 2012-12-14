jQuery.fn.modal = function (key) {
  var modal = $(this),
      modalForm = $('form', modal),
      action = key ? key : 'show',
      shade = $('.shade'),
      position = function(animate) {
        var width = modal.width(),
            height = modal.height(),
            centerFromContext = (window.innerHeight - height) / 2;

        modal.css('left', (window.innerWidth - width) / 2);
        if (animate) {
          modal.animate({ top: centerFromContext }, 'fast');
        } else {
          modal.css('top', centerFromContext);
        }
      };

  if (shade.length === 0) {
    shade = $('body').append('<div class="shade"></div>');
  }

  if (action == 'hide') {
    action = 'remove';
  }

  $(window).resize(function () {
    position(false);
  });

  modal[action]();
  shade[action]();

  if (modalForm && modalForm.length > 0) {
    modalForm.find('input:first-of-type').focus();
  }

  position(true);

};