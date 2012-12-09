define('dashboard', ['jquery', 'underscore'], function ($, _) {
  var recentCommentTemplate = $('li', '.recentComments'),
      recentDraftsTemplate = $('li', '.recentDrafts');

  $.ajax({
    url: '/comments/count',
    dataType: 'JSON',
    success: function (stats) {
      $('.commentsCount').text(stats.total);
      $('.spamCount').text(stats.spam);
    }
  });

  $.ajax({
    url: '/comments/recent',
    dataType: 'JSON',
    success: function (recentComments) {
      _.each(recentComments, function (comment) {
        var template = recentCommentTemplate.clone();
        template.find('p').text(comment.Body);
        template.find('label').text(comment.Author);
        template.find('a').attr('href', 'comments/modify?Id=' + comment.Id);

        $('.recentComments').append(template);
      });

      recentCommentTemplate.remove();
      recentCommentTemplate = undefined;
    }
  });

  $.ajax({
    url: '/articles/count',
    dataType: 'JSON',
    success: function (stats) {
      $('.articlesCount').text(stats.total);
      $('.draftsCount').text(stats.draft);
    }
  });

  $.ajax({
    url: '/articles/recent-drafts',
    dataType: 'JSON',
    success: function (recentDrafts) {
      _.each(recentDrafts, function (draft) {
        var template = recentDraftsTemplate.clone();
        template.find('a').attr('href', '/articles/compose?Id=' + draft.Id);
        template.find('label').text(draft.Title);

        $('.recentDrafts').append(template);
      });

      recentDraftsTemplate.remove();
      recentDraftsTemplate = undefined;
    }
  });

});