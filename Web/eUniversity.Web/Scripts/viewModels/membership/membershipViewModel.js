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

    self.SelectedUsers = ko.computed(function () {
        return ko.utils.arrayFilter(self.Users(), function (user) {
            return user.IsSelected();
        });
    });
    
    self.ApproveUser = function () {
        var userIds = ko.utils.arrayMap(self.SelectedUsers(), function(user) {
            return user.Id();
        });
        $.ajax({
            url: '/Membership/ActivateUser',
            type: "POST",
            data: JSON.stringify({ userIds: userIds }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

            }
        });
    };

    self.DeleteUser = function () {

    };

    self.IsAnySelected = ko.computed(function () {
        return self.SelectedUsers().length;
    });
    
    self.IsAnySelectedDontApproved = ko.computed(function () {
        var item = ko.utils.arrayFirst(self.SelectedUsers(), function (user) {
            return user.IsSelected() && !user.IsApproved();
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
