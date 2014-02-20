function SubjectRowViewModel(serverModel) {
    var self = this;
    self.IsSelected = ko.observable();
    
    self.Id = ko.observable();
    self.SubjectName = ko.observable();
    self.SemesterNumber = ko.observable();
    self.CurriculumName = ko.observable();
    self.SpecializationName = ko.observable();
    
    ko.mapping.fromJS(serverModel, {}, self);
}