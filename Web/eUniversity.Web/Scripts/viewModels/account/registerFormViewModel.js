function RegisterFormViewModel(serverModel) {
    var self = this;

    self.Register = ko.observable();
    self.Profile = ko.observable();
    self.Errors = ko.observableArray();

    var mappingOverride =
    {
        "Register":
        {
            create: function (options) {
                return new window.RegisterViewModel(options.data);
            }
        },
        'Profile':
        {
            create: function (options) {
                return new window.ProfileViewModel(options.data, options.parent.Register().AccountType);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);
}