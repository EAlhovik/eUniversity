function ProfileViewModel(serverModel, accountType) {
    var self = this;
    
    self.IsStudent = ko.computed(function () {
        return accountType() == 0; //todo: set val to const
    });
    
    self.FirstName = ko.observable().extend({ required: true });
    self.LastName = ko.observable().extend({ required: true });
    self.Group = ko.observable().extend({
        required: {
            message: "This field is required.",
            onlyIf: function () { return self.IsStudent(); }
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