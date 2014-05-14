﻿function StudentDashboardViewModel(serverModel) {
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

    function chooseCurrentSemester() {
        var index = 0;
        var activeItem = ko.utils.arrayFirst(self.Semesters(), function (item) {
            index++;
            return item.IsCurrent();
        });
        if (activeItem != null) {
            setCurrentStep(index - 1);
        }
    }


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

    chooseCurrentSemester();
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
        return new window.SubjectViewModel(data);
    }
}

function SubjectViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Assignee = ko.observable();
    self.SubjectType = ko.observable();
    self.SubjectDetail = ko.observable();

    self.IsExpand = ko.observable();
    self.IsLoading = ko.observable();

    if (serverModel != null) {
        ko.mapping.fromJS(serverModel, {}, self);
    }

    self.Expand = function () {
        self.IsExpand(!self.IsExpand());
        if (self.IsExpand()) {
            $.get(window.actions.dashboard.GetSubjectDetailUrl, { subjectId: self.Id() }, function (subjectDetail) {
                var subjectMapping =
                {
                    'SubjectDetail':
                    {
                        create: function (options) {
                            return new SubjectDetailViewModel(options.data);
                        }
                    }
                };
                var detail = ko.mapping.fromJS({ SubjectDetail: subjectDetail }, subjectMapping);
                self.SubjectDetail(detail.SubjectDetail);
            });
        }
    };
}

function SubjectDetailViewModel(serverModel) {
    var self = this;

    self.Id = ko.observable();
    self.Theme = ko.observable();

    if (serverModel != null) {
        ko.mapping.fromJS(serverModel, {}, self);
    }
}