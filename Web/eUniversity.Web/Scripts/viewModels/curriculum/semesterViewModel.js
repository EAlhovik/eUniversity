function SemesterViewModel(serverModel) {
    var self = this;
    self.IsActive = ko.observable(false);
    self.IsCompleted = ko.observable(false);

    self.Sequential = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);
    
}