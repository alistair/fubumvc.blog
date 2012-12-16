define('dashboard-graph-helper', ['jquery', 'underscore', 'd3'], function ($, _, d3) {
  var gridBuilder = {},
      barWidth = 28,
      maxBarHeight = 80,
      minBarHeight = 8,
      margin = 15,
      line = d3.scale.linear,
      x = line().domain([0, 1]).range([0, barWidth]),
      y = line().domain([0, maxBarHeight + 11]).rangeRound([minBarHeight, maxBarHeight]),
      chartAppender = function(type, valName, data) {
        return this.selectAll(type)
          .data(data).enter().append(type)
          .attr('x', function(day, i) {
            return x(i) - .5 + margin;
          })
          .attr('y', function(day) {
            return maxBarHeight - y(day[valName]) - .5;
          })
          .attr('width', barWidth - margin)
          .attr('height', function(day) {
            return y(day[valName]);
          });
      },
      drawCountText = function(item, name, data) {
        chartAppender.call(item, 'text', name, data)
          .attr('text-anchor', 'top')
          .attr('dy', 7)
          .attr('dx', 2)
          .text(function(day) { return day[name]; });
      };

  gridBuilder.build = function (chartSelector, gridData) {
    var data = gridData.data,
        chart = d3.select(chartSelector).attr('height', maxBarHeight),
        chartDateArea = chart.append('g').attr('class','dates');

    _.each(gridData.bars, function (key, i) {
      var area = chart.append('g').attr('transform', 'translate('+ (i * 10) +',-10)');
      chartAppender
        .call(area, 'rect', key, data)
        .attr('class', key);

      drawCountText(area, key, data);
    });

    chartAppender.call(chartDateArea, 'text', gridData.bars[0], data)
       .attr('text-anchor', 'right')
       .attr('y', maxBarHeight)
       .text(function(day) { return day[gridData.description]; });

    chartDateArea.append("line")
      .attr("y1", maxBarHeight - 11)
      .attr("y2", maxBarHeight - 11)
      .attr("x2", $(chartSelector).width());
  };

  return gridBuilder;
});