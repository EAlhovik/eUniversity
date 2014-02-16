function ProfileViewModel(serverModel) {
    var self = this;
    self.FirstName = ko.observable().extend({ required: true });
    self.LastName = ko.observable().extend({ required: true });
    self.Group = ko.observable().extend({
        validation: {
            validator: function (val) {
                return val != null;
            },
            message: 'This field is required.',
        }
    });

    ko.mapping.fromJS(serverModel, {}, self);
    
    self.register = function () {
        if (self.validate()) {
            return true;
        }
        return false;
    };

    addValidation(self);
}