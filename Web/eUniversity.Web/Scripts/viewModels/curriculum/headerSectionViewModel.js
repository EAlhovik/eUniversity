function HeaderSectionViewModel(serverModel) {
    var self = this;
    self.IsActive = ko.observable(true);
    self.IsCompleted = ko.observable(false);
    self.SpecializationId = ko.observable();
    self.CountSemesters = ko.observable();
    self.DateOfEnactmentDisplay = ko.observable();
    
    ko.mapping.fromJS(serverModel, {}, self);
}