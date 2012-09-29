﻿define('validation', ['jquery', 'underscore', 'messaging'], function ($, _, messaging) {
  var validation = { ajax: {} },
      buildSummary = function () {
        return {
          body: $('<ol></ol>'),
          add: function (errorMessage) {
            this.body.append('<li>' + errorMessage + '</li>');
          },
          getHtml: function(){
            return this.body[0].outerHTML;
          }
        };
      };

  validation.ajax.validate = function (options) {
    var callback = options.success,
      request = $.extend(options, {
        success: function (data) {
          var errors = data.errors,
              summary = buildSummary();

          if (errors) {

            _.each(errors, function (error) {
              $('[name="' + error.propertyName + '"]').addClass('error');
              summary.add(error.errorMessage);
            });

            messaging.raiseError(options.form, summary.getHtml());
          } else {
            callback(data);
          }
        }
      });

    $.ajax(request);
  };

  return validation;
});