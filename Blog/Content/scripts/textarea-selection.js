define('textarea-selection', ['jquery'], function ($) {
    var textarea = {},
        detectNewLineCharacters = function (length) {
            var position = length;
            for (var i = 0; i < length; i++) {
                if (e.value[i].search(/[\r\n]/) != -1) {
                    position = startPosition - .5;
                }
            }

            return position;
        },
        setSelection = function (selector, startPosition, endPosition) {
            var e = $(selector)[0];

            e.focus();
            if ('selectionStart' in e) {
                e.selectionStart = startPosition;
                e.selectionEnd = endPosition;
            }
            else if (document.selection) { //IE
                var tr = e.createTextRange();

                startPosition = detectNewLineCharacters(startPosition);
                endPosition = detectNewLineCharacters(endPosition);

                tr.moveEnd('textedit', -1);
                tr.moveStart('character', startPosition);
                tr.moveEnd('character', endPosition - startPosition);
                tr.select();
            }
        };

    textarea.get = function (selector) {
        var e = $(selector)[0];

        if ('selectionStart' in e) {
            var length = e.selectionEnd - e.selectionStart;
            return {
                start: e.selectionStart,
                end: e.selectionEnd,
                text: e.value.substr(e.selectionStart, length)
            };
        }
        else if (document.selection) { //IE
            e.focus();
            var r = document.selection.createRange(),
                tr = e.createTextRange(),
                tr2 = tr.duplicate();
            tr2.moveToBookmark(r.getBookmark());
            tr.setEndPoint('EndToStart', tr2);

            if (r == null || tr == null) return {
                start: e.value.length,
                end: e.value.length,
                text: ''
            };

            var text_part = r.text.replace(/[\r\n]/g, '.'), //for some reason IE doesn't always count the \n and \r in the length
                text_whole = e.value.replace(/[\r\n]/g, '.'),
                the_start = text_whole.indexOf(text_part, tr.text.length);

            return {
                start: the_start,
                end: the_start + text_part.length,
                text: r.text
            };
        }
        else return {
            start: e.value.length,
            end: e.value.length,
            text: ''
        };
    };

    textarea.insert = function (selector, val) {
        var e = $(selector),
            selection = textarea.get(selector),
            startPosition = selection.start;

        e.val(e.val().substr(0, startPosition) + val + e.val().substr(selection.end, e.val().length));
    };

    textarea.insertWithSelection = function (selector, val, selectionText) {
        var e = $(selector),
            index;

        textarea.insert(selector, val);
        index = e.val().indexOf(val) + val.indexOf(selectionText);;

        setSelection(selector, index, index + selectionText.length);
        textarea.get(selector);
    };

    textarea.insertToEnd = function (selector, val) {
        var e = $(selector);

        e.val(e.val() + val);
    };

    textarea.replace = function (selector, val) {
        var e = $(selector),
            selection = textarea.get(selector),
            startPosition = selection.start,
            endPosition = startPosition + val.length;

        e.val(e.val().substr(0, startPosition) + val + e.val().substr(selection.end, e.val().length));
        setSelection(selector, startPosition, endPosition);
    };

    textarea.wrap = function (selector, leftString, rightString) {
        textarea.replace(selector,
            leftString + textarea.get(selector).text + rightString);
    };



    return textarea;

});