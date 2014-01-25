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
ko.bindingHandlers.select2 = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        function createItem(item) {
            item.id = item.Id;
            item.text = item.Text;
            return item;
        }
        var obj = valueAccessor(),
            allBindings = allBindingsAccessor(),
            lookupKey = allBindings.lookupKey;
        if (obj.ajax) {
            obj.ajax.dataType = obj.ajax.dataType || 'json';
            obj.ajax.data = obj.ajax.data || function (term) {
                return {
                    term: term,
                    page_limit: 10,
                };
            };
            obj.ajax.results = obj.ajax.results || function (data) {
                data.forEach(createItem);
                return { results: data };
            };
        }
        $(element).select2(obj);
        if (lookupKey) {
            var value = ko.utils.unwrapObservable(allBindings.value);
            $.ajax(obj.ajax.url, {
                dataType: "json"
            }).done(function (data) {
                data.forEach(createItem);
                $(element).select2('data', ko.utils.arrayFirst(data, function (item) {
                    return item[lookupKey] == value;
                }));
            });
        }

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).select2('destroy');
        });
    },
    update: function (element) {
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