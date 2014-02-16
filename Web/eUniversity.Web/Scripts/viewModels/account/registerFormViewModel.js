function RegisterFormViewModel(serverModel) {
    var self = this;

    self.Register = ko.observable();
    self.Profile = ko.observable();

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
                return new window.ProfileViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);
}