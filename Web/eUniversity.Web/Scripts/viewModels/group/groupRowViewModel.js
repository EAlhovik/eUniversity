function GroupRowViewModel(serverModel, save) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.SpecializationId = ko.observable();
    self.DateOfAdmissionDisplay = ko.observable();

    self.IsSelected = ko.observable();

    if (serverModel != null)
        ko.mapping.fromJS(serverModel, {}, self);
    
    self.Save = function (viewModel) {
        viewModel.DateOfAdmissionDisplay(viewModel.DateOfAdmissionDisplay().format('YYYY-MM-DD'));
        
        save({ viewModels: [ko.mapping.toJS(viewModel)] });
    };
}