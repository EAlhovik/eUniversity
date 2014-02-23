function GroupRowViewModel(serverModel, save) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.SpecializationId = ko.observable();

    self.IsSelected = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.EditGroupUrl = ko.computed(function () {//todo: remove
        return window.actions.group.EditGroupUrl.replace('id', self.Id());
    });
    
    self.Save = function (viewModel) {
        save({ viewModels: [ko.mapping.toJS(viewModel)] });
    };
}