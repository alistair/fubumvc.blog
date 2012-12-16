require(['jquery', 'underscore', 'dashboard-graph-helper'], function ($, _, graph) {
  var recentCommentTemplate = $('li', '.recentComments'),
      recentDraftsTemplate = $('li', '.recentDrafts');

  //data = [
  //  {
  //    postedArticleCount: 80,
  //    draftArticleCount: 12,
  //    postedDate: '10/1'
  //  },
  //  {
  //    postedArticleCount: 8,
  //    draftArticleCount: 50,
  //    postedDate: '10/2'
  //  },
  //  {
  //    postedArticleCount: 40,
  //    draftArticleCount: 12,
  //    postedDate: '10/12'
  //  },
  //  {
  //    postedArticleCount: 3,
  //    draftArticleCount: 5,
  //    postedDate: '11/1'
  //  },
  //  {
  //    postedArticleCount: 30,
  //    draftArticleCount: 5,
  //    postedDate: '11/3'
  //  },
  //  {
  //    postedArticleCount: 1,
  //    draftArticleCount: 1,
  //    postedDate: '11/1'
  //  }
  //];

  
  //data = [
  //  {
  //    postedCommentsCount: 30,
  //    spamCount: 12,
  //    postedDate: '10/1'
  //  },
  //  {
  //    postedCommentsCount: 8,
  //    spamCount: 12,
  //    postedDate: '10/2'
  //  },
  //  {
  //    postedCommentsCount: 20,
  //    spamCount: 12,
  //    postedDate: '10/12'
  //  }
  //];

  $.ajax({
    url: '/comments/count',
    dataType: 'JSON',
    success: function (stats) {
      $('.commentsCount').text(stats.total);
      $('.spamCount').text(stats.spam);

      graph.build('#chart-comments', {
        description: 'postedDate',
        bars: ['postedCommentsCount', 'spamCount'],
        data : []
      });

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

      graph.build('#chart-articles', {
        description: 'postedDate',
        bars: ['postedArticleCount', 'draftArticleCount'],
        data : stats.history
      });
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