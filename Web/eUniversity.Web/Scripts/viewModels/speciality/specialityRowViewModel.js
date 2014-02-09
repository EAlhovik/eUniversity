function SpecialityRowViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();

    self.IsSelected = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.EditSpecialityUrl = ko.computed(function () {
        return window.actions.speciality.EditSpecialityUrl.replace('id', self.Id());
    });
}