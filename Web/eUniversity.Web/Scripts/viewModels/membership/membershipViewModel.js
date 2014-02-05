function MembershipViewModel(serverModel) {
    var self = this;
    self.Users = ko.observableArray();

    ko.mapping.fromJS(serverModel, {}, self.Users);
}

function UserRowViewModel(serverModel) {
    var self = this;

    ko.mapping.fromJS(serverModel, {}, self);
}