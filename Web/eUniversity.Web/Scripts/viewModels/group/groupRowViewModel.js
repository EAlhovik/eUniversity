function GroupRowViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();

    self.IsSelected = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.EditGroupUrl = ko.computed(function () {
        return window.actions.group.EditGroupUrl.replace('id', self.Id());
    });
}