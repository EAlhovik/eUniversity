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

    ko.mapping.fromJS(serverModel, {}, self);

    self.Expand = function() {
        self.IsExpand(!self.IsExpand());
    };

    self.IsExpand.subscribe(function() {
        if (self.IsExpand()) {
            loadSubjectWithThemes();
        }
    });

    function loadSubjectWithThemes() {
        self.IsLoading(true);
        $.ajax({
            url: window.actions.subject.GetSubjectRowUrl,
            data: { id: self.Id() },
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function(data) {
                ko.mapping.fromJS(data, {}, self);
            },
            complete: function () {
                self.IsLoading(false);
            }
        });
    }

    self.AddTheme = function() {
        self.Themes.push('');
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
        query: function (query) {
            $.ajax(getUrl('GetSelectedItemsUrl'), {
                data: {
                    term: query.term
                },
                dataType: "json"
            }).done(function (data) {
                data = data || [];
                data.push({ Id: query.term + window.constants.SubjectIdPrefix, Text: query.term });
                query.callback({ results: data });
            });
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