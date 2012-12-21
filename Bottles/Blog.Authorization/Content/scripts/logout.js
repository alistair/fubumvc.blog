﻿require(['jquery'], function ($) {
  var count = 5,
    counter = $('#count'),
    id = setInterval(function () {
      count--;

      if (count === 0) {
        clearInterval(id);
        window.location = "/";
      }

      counter.text(count);
    }, 1000);

  $('.current').hide();
});