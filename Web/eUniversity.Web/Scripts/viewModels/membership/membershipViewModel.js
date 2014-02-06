function MembershipViewModel(serverModel) {
    var self = this;
    self.Users = ko.observableArray();

    var mappingOverride =
    {
        "Users":
        {
            create: function (options) {
                return new window.UserRowViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);
    
    self.ShowProfile = function () {

    };

    self.ApproveUser = function () {

    };

    self.DeleteUser = function () {

    };
}
