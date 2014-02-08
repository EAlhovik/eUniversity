function UserRowViewModel(serverModel) {
    var self = this;
    self.IsApproved = ko.observable();
    self.UserName = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.IsSelected = ko.observable();

    self.ShowProfile = function() {

    };

    self.ApproveUser = function () {

    };

    self.DeleteUser = function () {

    };

    self.StatusDisplay = ko.computed(function() {
        return self.IsApproved() ? window.strings.common.Approved :
            window.strings.common.Draft;
    });
}