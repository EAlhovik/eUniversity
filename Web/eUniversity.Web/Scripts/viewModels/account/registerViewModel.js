function RegisterViewModel(serverModel) {
    var self = this;
    
    self.Email = ko.observable().extend({ required: true, email: true });
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
    self.AccountType = ko.observable();
    
    ko.mapping.fromJS(serverModel, {}, self);
    
    self.register = function () {
        if (self.validate()) {
            return true;
        }
        return false;
    };

    addValidation(self);
}