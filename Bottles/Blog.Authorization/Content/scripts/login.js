require(['jquery'], function ($) {
  if ($('#authorization').length > 0) {
    window.location = '/profile';
    return;
  }

  $('form').show();
  openid.init('OpenidIdentifier');
});