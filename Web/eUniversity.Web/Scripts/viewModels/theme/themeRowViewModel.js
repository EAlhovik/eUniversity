function ThemeRowViewModel(serverModel, save) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.LastModified = ko.observable();

    self.IsSelected = ko.observable();

    if (serverModel)
        ko.mapping.fromJS(serverModel, {}, self);

    self.Save = function (viewModel) {
        save({ viewModels: [ko.mapping.toJS(viewModel)] }, function (result) {

            ko.mapping.fromJS(result.Data[0], {}, self);
            
        });
    };
}