function StudentDashboardViewModel(serverModel) {
    var self = this;
    self.Semesters = ko.observableArray();

    var mappingOverride =
    {
        'Semesters':
        {
            create: function (options) {
                return new window.SemesterViewModel(options.data);
            }
        }
    };
    
    ko.mapping.fromJS(serverModel, mappingOverride, self);
    
    self.ChooseStep = function (step) {
        if (!step.IsReadOnly()) {
            var index = self.Semesters().indexOf(step);
            setCurrentStep(index);
        }
    };

    self.IsDisablePrevBtn = ko.computed(function () {
        var activeItem = firstActiveStep();
        return activeItem > 0;
    });

    function setCurrentStep(index) {
        var i = 0;
        ko.utils.arrayForEach(self.Semesters(), function (item) {
            item.IsCompleted(index > i);
            item.IsActive(index == i);
            i++;
        });
    }
    function firstActiveStep() {
        var activeItem = ko.utils.arrayFirst(self.Semesters(), function (item) {
            return item.IsActive();
        });
        return self.Semesters().indexOf(activeItem);
    }

    ko.computed(function () {
        ko.utils.arrayForEach(self.Semesters(), function (item) {
            item.IsLast(false);
        });
        var lastSem = self.Semesters()[self.Semesters().length - 1];
        lastSem.IsLast(true);
    });
}

function SemesterViewModel(serverModel) {
    var self = this;
    self.IsActive = ko.observable(false);
    self.IsCompleted = ko.observable(false);

    self.Subjects = ko.observableArray();
    self.Sequential = ko.observable();
    self.IsReadOnly = ko.observable();

    self.Title = ko.computed(function () {
        return 'Семестр ' + self.Sequential();
    });

    self.IsLast = ko.observable(false);

    var mappingOverride =
    {
        'Subjects':
        {
            create: function (options) {
                return createSubject(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);

    self.AddNewSubject = function () {
        self.Subjects.push(createSubject(null));
    };

    function createSubject(data) {
        return new window.SubjectViewModel(data, self.IsLast);
    }

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
        minimumInputLength: 0,
        query: function (query) {
            $.ajax("/Loockup/GetSubjects", {
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
                url: window.actions.curriculum.GetSubject,
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

function SubjectViewModel(serverModel, isLast) {
    var self = this;
    self.Id = ko.observable();
    self.Assignee = ko.observable();
    self.SubjectType = ko.observable();
    
    self.IsExpand = ko.observable();
    self.IsLoading = ko.observable();

    if (serverModel != null) {
        ko.mapping.fromJS(serverModel, {}, self);
    }
    
    self.Expand = function () {
        self.IsExpand(!self.IsExpand());
    };

    self.select2ForSubjectType = {
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
        minimumInputLength: 0,
        query: function (query) {
            $.ajax(window.actions.curriculum.GetSubjectTypesUrl, {
                data: {
                    term: query.term,
                    isLast: isLast()
                },
                dataType: "json"
            }).done(function (data) {
                data = data || [];
                query.callback({ results: data });
            });
        },
        initSelection: function (element, callback) {
            var id = $(element).val();
            if (id !== "") {
                var data = self.select2ForSubjectType.loadElement(id);
                callback(data);
            }
        },
        loadElement: function (id) {
            var res;
            $.ajax({
                url: window.actions.curriculum.GetSubjectTypeUrl,
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