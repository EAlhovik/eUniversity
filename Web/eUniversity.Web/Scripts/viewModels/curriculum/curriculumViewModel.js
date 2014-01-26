function CurriculumViewModel(serverModel) {
    var self = this;
    self.CurriculumHeader = ko.observable();
    self.Semesters = ko.observableArray();
    self.Steps = ko.observableArray();

    var mappingOverride =
    {
        "CurriculumHeader":
        {
            create: function (options) {
                return new window.HeaderSectionViewModel(options.data);
            }
        },
        'Semesters':
        {
            create: function (options) {
                return new window.SemesterViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);
    self.Steps.push(new StepViewModel(self.CurriculumHeader().IsActive, self.CurriculumHeader().IsCompleted, 'Общая информация', '¤'));
    for (var i = 0; i < self.Semesters().length; i++) {
        self.Steps.push(new StepViewModel(self.Semesters()[i].IsActive, self.Semesters()[i].IsCompleted, 'Семестр ' + self.Semesters()[i].Sequential(), self.Semesters()[i].Sequential()));
    }

    self.BtnPrev = function () {
        var index = firstActiveStep();
        setCurrentStep(index - 1);
    };
    
    self.BtnNext = function () {
        var index = firstActiveStep();
        if (self.Steps().length - 1 != index) {
            setCurrentStep(index + 1);
        } else {
            save();
//            $('#curriculumForm').submit();
        }
        
    };

    self.ChooseStep = function(step) {
        var index = self.Steps().indexOf(step);
        setCurrentStep(index);
    };

    self.IsDisablePrevBtn = ko.computed(function () {
        var activeItem = firstActiveStep();
        return activeItem > 0;
    });

    function save() {
        $.ajax({
            url: '/Curriculum/Edit',
            type: "POST",
            data: JSON.stringify({ curriculum: ko.mapping.toJS(self) }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                    ko.mapping.fromJS(data, {}, self);
            },
            complete: function (param1, status) {
            }
        });
    }

    function setCurrentStep(index) {
        var i = 0;
        ko.utils.arrayForEach(self.Steps(), function (item) {
            item.IsCompleted(index > i);
            item.IsActive(index == i);
            i++;
        });
    }
    function firstActiveStep() {
        var activeItem = ko.utils.arrayFirst(self.Steps(), function (item) {
            return item.IsActive();
        });
        return self.Steps().indexOf(activeItem);
        //        ko.utils.arrayIndexOf(self.Steps(), activeItem);
    }
}

function StepViewModel(isActive, isCompleted, title, step) {
    var self = this;
    self.IsActive = isActive;
    self.IsCompleted = isCompleted;
    self.Title = ko.observable(title);
    self.Step = ko.observable(step);
}