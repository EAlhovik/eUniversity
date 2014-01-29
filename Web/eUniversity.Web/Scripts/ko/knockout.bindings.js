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
            if (item.hasOwnProperty('Id')){
                return item.Id();
            }
            item.Text = ko.observable(item.text);
            item.Id = ko.observable(item.id);
            return item.Id();
        };
        var format = function (current) {
            return (current.Text() || "").toString();
        };
        options.formatResult = format;
        options.formatSelection = format;
        options.initSelection = function(element, callback) {
            var data = $(element).select2('data');
            callback(data);
        };
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
        var events = allBindingsAccessor().select2Event || {};
        for (var event in events) {
            $(element).on(event, events[event]);
        }
        
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
/********** Bootstrap Modals ***************/
var createModalElement = function (templateName, viewModel) {
    var temporaryDiv = addHiddenDivToBody();
    var deferredElement = $.Deferred();
    ko.renderTemplate(
        templateName,
        viewModel,
        // We need to know when the template has been rendered,
        // so we can get the resulting DOM element.
        // The resolve function receives the element.
        {
            afterRender: function (nodes) {
                // Ignore any #text nodes before and after the modal element.
                var elements = nodes.filter(function (node) {
                    return node.nodeType === 1; // Element
                });
                deferredElement.resolve(elements[0]);
            }
        },
        // The temporary div will get replaced by the rendered template output.
        temporaryDiv,
        "replaceNode"
    );
    // Return the deferred DOM element so callers can wait until it's ready for use.
    return deferredElement;
};

var addHiddenDivToBody = function () {
    var div = document.createElement("div");
    div.style.display = "none";
    document.body.appendChild(div);
    return div;
};
var addModalHelperToViewModel = function (viewModel, deferredModalResult, context) {
    // Provide a way for the viewModel to close the modal and pass back a result.
    viewModel.modal = {
        close: function (result) {
            if (typeof result !== "undefined") {
                deferredModalResult.resolveWith(context, [result]);
            } else {
                // When result is undefined, we don't want any `done` callbacks of
                // the deferred being called. So reject instead of resolve.
                deferredModalResult.rejectWith(context, []);
            }
        }
    };
};

//pipe(function (modalElement) {
//    return $(modalElement);
//})

var showTwitterBootstrapModal = function ($ui) {
    // Display the modal UI using Twitter Bootstrap's modal plug-in.
    $ui.modal({
        // Clicking the backdrop, or pressing Escape, shouldn't automatically close the modal by default.
        // The view model should remain in control of when to close.
        backdrop: "static",
        keyboard: false
    });
};

var whenModalResultCompleteThenHideUI = function (deferredModalResult, $ui) {
    // When modal is closed (with or without a result)
    // Then always hide the UI.
    deferredModalResult.always(function () {
        $ui.modal("hide");
    });
};

var whenUIHiddenThenRemoveUI = function ($ui) {
    // Hiding the modal can result in an animation.
    // The `hidden` event is raised after the animation finishes,
    // so this is the right time to remove the UI element.
    $ui.on("hidden", function () {
        // Call ko.cleanNode before removal to prevent memory leaks.
        $ui.each(function (index, element) { ko.cleanNode(element); });
        $ui.remove();
    });
};
var showModal = function (options) {
    if (typeof options === "undefined") throw new Error("An options argument is required.");
    if (typeof options.viewModel !== "object") throw new Error("options.viewModel is required.");

    var viewModel = options.viewModel;
    var template = options.template || viewModel.template;
    var context = options.context;

    if (!template) throw new Error("options.template or options.viewModel.template is required.");

    return createModalElement(template, viewModel)
        .pipe($) // jQueryify the DOM element
        .pipe(function ($ui) {
            var deferredModalResult = $.Deferred();
            addModalHelperToViewModel(viewModel, deferredModalResult, context);
            showTwitterBootstrapModal($ui);
            whenModalResultCompleteThenHideUI(deferredModalResult, $ui);
            whenUIHiddenThenRemoveUI($ui);
            return deferredModalResult;
        });
};