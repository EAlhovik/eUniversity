function SpecializationRowViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();

    self.IsSelected = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.EditSpecializationUrl = ko.computed(function () {
        return window.actions.specialization.EditSpecializationUrl.replace('id', self.Id());
    });
}