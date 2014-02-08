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

    self.IsAnySelected = ko.computed(function () {
        var item = ko.utils.arrayFirst(self.Users(), function (user) {
            return user.IsSelected();
        });
        return item != null;
    });

    self.IsAllSelected = ko.computed({
        read: function () {
            var isAllSelected = true;
            ko.utils.arrayForEach(self.Users(), function (user) {
                isAllSelected = isAllSelected && user.IsSelected();
            });
            return isAllSelected;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.Users(), function (user) {
                user.IsSelected(value);
            });
        },
        owner: self
    });
}
