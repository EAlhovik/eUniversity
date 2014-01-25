function CurriculumViewModel(serverModel) {
    var self = this;
    self.HeaderSection = ko.observable();
    self.Semesters = ko.observableArray();
    self.Steps = ko.observableArray();

    var mappingOverride =
    {
        'HeaderSection':
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
    self.Steps.push(new StepViewModel(self.HeaderSection().IsActive, self.HeaderSection().IsCompleted, 'Общая информация', '¤'));
    for (var i = 0; i < self.Semesters().length; i++) {
        self.Steps.push(new StepViewModel(self.Semesters()[i].IsActive, self.Semesters()[i].IsCompleted, 'Семестр ' + self.Semesters()[i].Sequential(), self.Semesters()[i].Sequential()));
    }

    self.BtnPrev = function () {
        var index = firstActiveStep();
        setCurrentStep(index - 1);
    };
    
    self.BtnNext = function () {
        var index = firstActiveStep();
        setCurrentStep(index + 1);
    };

    self.ChooseStep = function(step) {
        var index = self.Steps().indexOf(step);
        setCurrentStep(index);
    };

    self.IsDisablePrevBtn = ko.computed(function () {
        var activeItem = firstActiveStep();
        return activeItem > 0;
    });

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