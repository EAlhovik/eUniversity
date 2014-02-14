function ChangePasswordViewModel(serverModel) {
    var self = this;
    self.IsActive = ko.observable(false);

    ko.mapping.fromJS(serverModel, {}, self);
}