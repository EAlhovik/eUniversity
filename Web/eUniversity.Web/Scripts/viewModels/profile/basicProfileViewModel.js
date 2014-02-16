function BasicProfileViewModel(serverModel) {
    var self = this;
    self.GeneralSection = ko.observable();

    self.IsActive = ko.observable(true);
    var mappingOverride =
    {
        "GeneralSection":
        {
            create: function (options) {
                return new window.GeneralInfoSectionViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);
}