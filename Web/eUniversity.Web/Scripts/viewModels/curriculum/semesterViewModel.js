function SemesterViewModel(serverModel) {
    var self = this;
    self.IsActive = ko.observable(false);
    self.IsCompleted = ko.observable(false);

    self.Subjects = ko.observableArray();
    self.Sequential = ko.observable();

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

    self.AddSubject = function() {
        self.Subjects.push(new SubjectViewModel());
    };

    self.RemoveSubject = function(subject) {
        self.Subjects.remove(subject);
    };
}