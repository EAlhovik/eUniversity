function CurriculumViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.CurriculumHeader = ko.observable();
    self.Semesters = ko.observableArray();

    var mappingOverride =
    {
        "CurriculumHeader":
        {
            create: function (options) {
                return new window.CurriculumHeaderViewModel(options.data);
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


    self.Save = function() {
        save();
    };
    
    self.Reset = function() {
        document.location.reload(true);
    };
    
    self.ChooseStep = function (step) {
        var index = self.Semesters().indexOf(step);
        setCurrentStep(index);
    };

    self.IsDisablePrevBtn = ko.computed(function () {
        var activeItem = firstActiveStep();
        return activeItem > 0;
    });

    self.NewCountSemestersSelecting = function (e) {
        if (self.CurriculumHeader().CountSemesters() && confirm('Вы уверены?')) {
            $.ajax({
                url: window.actions.curriculum.NewCountSemestersUrl,
                type: "POST",
                data: JSON.stringify({ viewModel: ko.mapping.toJS(e.object) }),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    if (result.IsValid) {
                        ko.mapping.fromJS(result.Data, {}, self);
                    } else {
                        alert('error.');
                    }
                },
                complete: function (param1, status) {
                }
            });
        } else {
            e.preventDefault();
        }
    };

    function save() {
        $.ajax({
            url: '/Curriculum/Edit',
            type: "POST",
            data: JSON.stringify({ viewModel: ko.mapping.toJS(self) }),
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
}