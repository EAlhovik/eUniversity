function SubjectViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Assignee = ko.observable();
    self.SubjectType = ko.observable();

    self.IsSelected = ko.observable();

    if (serverModel != null) {
        ko.mapping.fromJS(serverModel, {}, self);
    }
}