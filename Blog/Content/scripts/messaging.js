define('messaging', ['jquery'], function () {
  var messaging = {},
    raiseMessage = function (container, message, cssClass, timeout) {
      var messageContent = $('<div></div>');

      messageContent.click(function () {
        messageContent.remove();
      });

      messageContent.addClass('messaging messaging-' + cssClass);
      messageContent.text(message);

      container.prepend(messageContent);

      if(timeout) {
        setTimeout(function () {
          messageContent.fadeOut('slow', function () {
            messageContent.remove();
          });
        }, timeout);
      }
    };

  messaging.raiseError = function (container, message) {
    raiseMessage(container, message, 'error');
  };

  messaging.raiseWarning = function (container, message) {
    raiseMessage(container, message, 'warning');
  };

  messaging.raiseSuccess = function (container, message) {
    raiseMessage(container, message, 'success', 5000);
  };

  messaging.raiseRemove = function (container, message) {
    raiseMessage(container, message, 'remove', 5000);
  };


  messaging.raiseInformation = function (container, message) {
    raiseMessage(container, message, 'information', 10000);
  };

  return messaging;
});