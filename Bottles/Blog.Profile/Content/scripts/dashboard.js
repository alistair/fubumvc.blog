require(['jquery', 'underscore', 'dashboard-graph-helper'], function ($, _, graph) {
  var recentCommentTemplate = $('li', '.recentComments'),
      recentDraftsTemplate = $('li', '.recentDrafts');



  $.ajax({
    url: '/comments/count',
    type: 'GET',
    dataType: 'JSON',
    success: function (stats) {
      $('.commentsCount').text(stats.total);
      $('.spamCount').text(stats.spam);

      graph.build('#chart-comments', {
        description: 'postedDate',
        bars: ['postedCommentsCount', 'spamCount'],
        data : stats.history
      });

    }
  });

  $.ajax({
    url: '/comments/recent',
    type: 'GET',
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
    type: 'GET',
    dataType: 'JSON',
    success: function (stats) {
      $('.articlesCount').text(stats.total);
      $('.draftsCount').text(stats.draft);

      graph.build('#chart-articles', {
        description: 'postedDate',
        bars: ['postedArticleCount', 'draftArticleCount'],
        data : stats.history
      });
    }
  });

  $.ajax({
    url: '/articles/recent-drafts',
    type: 'GET',
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