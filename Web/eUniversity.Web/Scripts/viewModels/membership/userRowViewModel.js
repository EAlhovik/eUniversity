function UserRowViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.IsApproved = ko.observable();
    self.UserName = ko.observable();
    self.Created = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.IsSelected = ko.observable();

    self.ShowProfile = function() {

    };

    self.ApproveUser = function () {
        $.ajax({
            url: '/Membership/ActivateUser',
            type: "POST",
            data: JSON.stringify({ userIds: [self.Id()] }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

            }
        });
    };

    self.DeleteUser = function () {

    };

    self.StatusDisplay = ko.computed(function() {
        return self.IsApproved() ? window.strings.common.Approved :
            window.strings.common.Draft;
    });
}