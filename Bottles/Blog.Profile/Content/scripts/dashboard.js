require(['jquery', 'underscore', 'd3'], function ($, _, d3) {
  //TODO: finish up chart code and move to dashboard, and cleanup

  var recentCommentTemplate = $('li', '.recentComments'),
      recentDraftsTemplate = $('li', '.recentDrafts'),
      barWidth = 15,
      maxBarHeight = 80,
      chart,
      data,
      line = d3.scale.linear,
      x = line().domain([0, 1]).range([0, barWidth]),
      y = line().domain([0, 100]).rangeRound([0, maxBarHeight]);

  data = [
    { postedArticleCount: 12 },
    { postedArticleCount: 1 },
    { postedArticleCount: 40 },
    { postedArticleCount: 3 },
    { postedArticleCount: 30 },
    { postedArticleCount: 1 }
  ];

  chart = d3.select("#chart").attr("height", maxBarHeight);

  chart.selectAll("rect")
    .data(data)
    .enter()
    .append("rect")
       .attr('class', 'posted-article')
       .attr("x", function(day, i) { return x(i) - .5; })
       .attr("y", function(day) { return maxBarHeight - y(day.postedArticleCount) - .5; })
       .attr("width", barWidth - 5)
       .attr("height", function(day) { return y(day.postedArticleCount); });

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