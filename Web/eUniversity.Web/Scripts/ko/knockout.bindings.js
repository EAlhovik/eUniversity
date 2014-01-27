/************* From submit  ***************/
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
/************* Select2 *********************/
ko.utils.setValue = function (property, newValue) {
    if (ko.isObservable(property))
        property(newValue);
    else
        property = newValue;
};

ko.bindingHandlers.select2 = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var obj = valueAccessor();
        var options = ko.toJS(obj);
        options.id = function (item) {
            return item.Id();
        };
        var format = function (current) {
            return (current.Text() || "").toString();
        };
        options.formatResult = format;
        options.formatSelection = format;
        options.initSelection = function (element, callback) {
            var data = $(element).select2('data');
            callback(data);
        }
        if (options.ajax) {
            options.ajax.dataType = 'json';
            options.ajax.data = function(term) {
                return {
                    term: term
                };
            };
            options.ajax.results = function(data) {
                return { results: ko.mapping.fromJS(data)() };
            };
        }

        $(element).select2(options);

        ko.utils.registerEventHandler(element, "select2-selected", function (data) {
            if ('selectedValue' in allBindingsAccessor()) {
                ko.utils.setValue(allBindingsAccessor().selectedValue, data.choice);
            }
        });

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).select2('destroy');
        });
    },
    update: function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().select2Options || {};

        for (var property in options) {
            $(element).select2(property, ko.utils.unwrapObservable(options[property]));
        }

        $(element).trigger('change');
    }
};
/**************** date picker **************/
ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var obj = valueAccessor(),
            allBindings = allBindingsAccessor();
        obj.autoclose = obj.autoclose || true;
        obj.format = obj.format || 'dd.mm.yyyy';
        obj.language = obj.language || "ru";
        obj.todayBtn = obj.todayBtn || 'linked';

        $(element).datepicker(obj).next().on("click", function () {
            $(this).prev().focus();
        });
        var date = ko.utils.unwrapObservable(allBindings.value);
        $(element).datepicker('update', date);
    },
    update: function (element) {
        $(element).trigger('change');
    }
};