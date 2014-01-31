function SemesterViewModel(serverModel) {
    var self = this;
    self.IsActive = ko.observable(false);
    self.IsCompleted = ko.observable(false);

    self.Subjects = ko.observableArray();
    self.Sequential = ko.observable();
    
    self.Title = ko.computed(function () {
        return 'Семестр ' + self.Sequential();
    });

    var mappingOverride =
    {
        'Subjects':
        {
            create: function (options) {
                return new window.SubjectViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);

    

    self.AddSubject = function () {
        showModal({ viewModel: new SubjectViewModel() })
        .done(function (result) {
//            self.Subjects.push(result);
            self.Subjects.push(new window.SubjectViewModel(ko.toJS(result)));
            console.log("Modal closed with result: " + result);
        })
        .fail(function () {
            console.log("Modal cancelled");
        });
//        self.Subjects.push(new SubjectViewModel());
    };

    self.RemoveSubject = function (subject) {
        self.Subjects.remove(subject);
    };
}