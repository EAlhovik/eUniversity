ko.bindingHandlers.deferredSubmit = {
    init: function (element, func) {
        var submit = function () {
            var i = func()();
            if (i) {
                $(element).unbind("submit", submit).submit();
            }
            
            return false;
        };
        $(element).bind("submit", submit);
    }
};

ko.validation.configure({
    registerExtenders: true,
    messagesOnModified: true,
    decorateElement: true,
    errorClass: 'has-error',
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: null
});