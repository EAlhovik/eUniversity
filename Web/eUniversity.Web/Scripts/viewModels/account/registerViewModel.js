function RegisterViewModel(serverModel) {
    var self = this;

    self.UserName = ko.observable().extend({ required: true });
    self.Password = ko.observable().extend({ required: true });
    self.ConfirmPassword = ko.observable().extend(
        {
        validation: {
            validator: function (val, other) {
                return val == other();
            },
            message: 'Passwords do not match.',
            params: self.Password
        }
    });
    
    ko.mapping.fromJS(serverModel, {}, self);

    addValidation(self);
}