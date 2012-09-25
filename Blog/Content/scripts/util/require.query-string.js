define('query-string', [], function () {
    var query = { },
        match,
        queryString = window.location.search.substring(1),
        replacePlusWithSpaceRegex = /\+/g,
        regex = /([^&=]+)=?([^&]*)/g,
        decodeUri = function (string) {
            return decodeURIComponent(string.replace(replacePlusWithSpaceRegex, ' '));
        };

    query.getParameterByName = function (name) {
        match = RegExp(name + '=([^&]*)').exec(queryString);

        return match && decodeUri(match[1]);
    };

    query.getParameters = function () {
        var params = { };
        while (match = regex.exec(queryString)) {
            params[decodeUri(match[1])] = decodeUri(match[2]);
        }

        return params;
    };

    return query;
});