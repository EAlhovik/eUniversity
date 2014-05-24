function ProfessorDashboardViewModel(serverModel) {
    var self = this;
    self.Filter = ko.observable();
    self.CountSubjects = ko.observable();
    self.Students = ko.observableArray();

    var mappingOverride =
    {
        'Filter':
        {
            create: function (options) {
                return new window.FilterViewModel(options.data);
            }
        },
        'Students':
        {
            create: function (options) {
                return new window.StudentRowViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);

    self.ApplyFilter = function () {
        $.ajax({
            url: window.actions.dashboard.GetProfessorDashboardUrl,
            type: "POST",
            data: JSON.stringify({ filter: ko.mapping.toJS(self.Filter()) }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var mapping = {
                    'Students':
                    {
                        create: function(options) {
                            return new window.StudentRowViewModel(options.data);
                        }
                    },
                    'ignore': ["Filter"]
                };
                ko.mapping.fromJS(result, mapping, self);
            },
            complete: function () {
//                self.IsLoading(false);
            }
        });
    };
    
    ko.computed(function () {
        var group = self.Filter().Group();
        var semester = self.Filter().SemesterSeq();
        self.ApplyFilter();
    });
}

function FilterViewModel(serverModel) {
    var self = this;
    self.Group = ko.observable();
    self.SemesterSeq = ko.observable(); //todo: rename to semester or selectedSemester

    ko.mapping.fromJS(serverModel, {}, self);
}

function StudentRowViewModel(serverModel) {
    var self = this;
    self.Student = ko.observable();
    self.Student = ko.observable();
    
    self.Subjects = ko.observableArray();
    
    self.IsExpand = ko.observable();
    self.IsLoading = ko.observable();
    
    var mappingOverride =
    {
        'Subjects':
        {
            create: function (options) {
                return new window.StudentSubjectViewModel(options.data);
            }
        }
    };

    if (serverModel != null) {
        ko.mapping.fromJS(serverModel, mappingOverride, self);
    }

    self.Expand = function () {
        self.IsExpand(!self.IsExpand());
        if (self.IsExpand()) {
        }
    };
}

function StudentSubjectViewModel(serverModel) {
    var self = this;
    
    self.Theme = ko.observable();
    self.ThemeId = ko.observable();
    self.Subject = ko.observable();
    self.SubjectId = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.ThemeDisplay = ko.computed(function() {
        if (self.Theme()) {
            return self.Theme().Name();
        }
        return '';
    });

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
            url: window.actions.subject.GetSelectedItemsUrl, // themes
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
                url: window.actions.subject.GetSelectedItemUrl, // theme
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
}