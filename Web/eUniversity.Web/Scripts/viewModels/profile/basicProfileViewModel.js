function BasicProfileViewModel(serverModel) {
    var self = this;
    self.GeneralSection = ko.observable();
//    self.ContactSection = ko.observable();
//    self.SocialSection = ko.observable();

    self.IsActive = ko.observable(true);
    var mappingOverride =
    {
        "GeneralSection":
        {
            create: function (options) {
                return new window.GeneralInfoSectionViewModel(options.data);
            }
        },
      /*  "ContactSection":
        {
            create: function (options) {
                return new window.ContactInfoSectionViewModel(options.data);
            }
        },
        "SocialSection":
        {
            create: function (options) {
                return new window.ContactInfoSectionViewModel(options.data);
            }
        },*/
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);
}