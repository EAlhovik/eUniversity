function SpecializationRowViewModel(serverModel, save) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.SpecialityId = ko.observable();

    self.IsSelected = ko.observable();

    if (serverModel)
    ko.mapping.fromJS(serverModel, {}, self);

    self.EditSpecializationUrl = ko.computed(function () {
        return window.actions.specialization.EditSpecializationUrl.replace('id', self.Id());
    });
    
    self.Save = function (viewModel) {
        save({ viewModels: [ko.mapping.toJS(viewModel)] });
    };
}