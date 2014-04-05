function SubjectRowViewModel(serverModel) {
    var self = this;
    self.IsSelected = ko.observable();
    self.IsExpand = ko.observable();
    self.IsLoading = ko.observable();

    self.Id = ko.observable();
    self.SubjectName = ko.observable();
    self.SemesterNumber = ko.observable();
    self.CurriculumName = ko.observable();
    self.SpecializationName = ko.observable();
    self.Themes = ko.observableArray();

    var mappingOverride =
    {
        "Themes":
        {
            create: function (options) {
                return new window.ThemeViewModel(options.data);
            }
        }
    };

    if (serverModel != null)
        ko.mapping.fromJS(serverModel, mappingOverride, self);

    self.Expand = function() {
        self.IsExpand(!self.IsExpand());
    };

    self.IsExpand.subscribe(function() {
        if (self.IsExpand()) {
            loadSubjectWithThemes();
        }
    });

    self.Save = function () {
        ajax(window.actions.subject.SaveSubjectUrl,JSON.stringify( { viewModel: ko.mapping.toJS(self) }), 'POST');
    };

    function loadSubjectWithThemes() {
        ajax(window.actions.subject.GetSubjectRowUrl, { id: self.Id() });
    }
    
    function ajax(url, data, type) {
        self.IsLoading(true);
        $.ajax({
            url: url,
            data: data,
            type: type || "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                ko.mapping.fromJS(result, mappingOverride, self);
            },
            complete: function () {
                self.IsLoading(false);
            }
        });
    }

    self.AddTheme = function() {
        self.Themes.push(new ThemeViewModel(null));
    };

    self.Remove = function(theme) {
        self.Themes.remove(theme);
    };

    self.select2 = {
        width: 200,
        id: function (item) {
            return item.Id;
        },
        formatResult: function (current) {
            return current.Text;
        },
        formatSelection: function (current) {
            return current.Text;
        },
        multiple: false,
        ajax: {
            data: function (term) {
                return {
                    term: term
                };
            },
            url: getUrl('GetSelectedItemsUrl'),
            results: function (data) {
                return { results: data };
            }
        },
        initSelection: function (element, callback) {
            var id = $(element).val();
            if (id !== "") {
                var data = self.select2.loadElement(id);
                callback(data);
            }
        },
        loadElement: function (id) {
            var res;
            $.ajax({
                url: getUrl('GetSelectedItemUrl'),
                data: { id: id },
                async: false,
                success: function (data) {
                    res = data;
                    return data;
                }
            });
            return res;
        }
    };
    
    function getUrl(name) {
        if (window.actions['subject'] && window.actions['subject'][name]) {
            return window.actions['subject'][name];
        }
        return '';  
    }
}

function ThemeViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Description = ko.observable();
    
    if (serverModel != null)
        ko.mapping.fromJS(serverModel, {}, self);

    self.Id.subscribe(function () {
        self.Description(null);
        if (self.Id())
        $.get(window.actions.subject.GetThemeDescriptionUrl, { id: self.Id() }, function (data) {
            self.Description(data);
        });
    });
}