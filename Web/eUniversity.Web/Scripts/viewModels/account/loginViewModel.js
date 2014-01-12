function LoginViewModel(serverModel) {
    var self = this;
    self.UserName = ko.observable().extend({ required: true });
    self.Password = ko.observable().extend({ required: true });
    self.RememberMe = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);
    
    self.login = function () {
        if (self.validate()) {
            return true;
        }
        return false;
    };

    addValidation(self);
}