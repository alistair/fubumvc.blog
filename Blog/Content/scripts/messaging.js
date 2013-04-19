define('messaging', ['jquery'], function () {
  var messaging = {},
    raiseMessage = function (container, message, cssClass, timeout) {
      var messageContent = $('<div></div>');

      $('.messaging').remove();

      messageContent.click(function () {
        messageContent.remove();
      });

      messageContent.addClass('alert alert-' + cssClass);
      messageContent.css('width', '100%');
      messageContent.html(message);

      container.prepend(messageContent);

      if (timeout) {
        setTimeout(function () {
          messageContent.fadeOut('slow', function () {
            messageContent.remove();
          });
        }, timeout);
      }
    };

  messaging.raiseError = function (container, message) {
    raiseMessage(container, message, 'danger');
  };

  messaging.raiseWarning = function (container, message) {
    raiseMessage(container, message, 'warning');
  };

  messaging.raiseSuccess = function (container, message) {
    raiseMessage(container, message, 'success', 5000);
  };

  messaging.raiseRemove = function (container, message) {
    raiseMessage(container, message, 'default', 5000);
  };

  messaging.raiseInformation = function (container, message) {
    raiseMessage(container, message, 'info', 10000);
  };

  return messaging;
});