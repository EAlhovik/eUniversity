function GroupRowViewModel(serverModel, save) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.SpecializationId = ko.observable();

    self.IsSelected = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);
    
    self.Save = function (viewModel) {
        save({ viewModels: [ko.mapping.toJS(viewModel)] });
    };
}