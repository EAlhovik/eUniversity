function GeneralInfoSectionViewModel(serverModel) {
    var self = this;
    self.UserName = ko.observable();
    self.FirstName = ko.observable();
    self.LastName = ko.observable();
    self.LastName = ko.observable();
    self.BithDayDisplay = ko.observable();
    self.IsMale = ko.observable();
    self.Comment = ko.observable();
    
    ko.mapping.fromJS(serverModel, {}, self);
}