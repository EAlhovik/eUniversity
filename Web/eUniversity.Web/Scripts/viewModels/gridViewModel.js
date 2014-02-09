function GridViewModel(serverModel) {
    var self = this;
    self.Rows = ko.observableArray();
    
    var mappingOverride =
    {
        "Rows":
        {
            create: function (options) {
                return eval('new ' + options.data.ViewModel + '(options.data)');
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);
    
    self.SelectedRows = ko.computed(function () {
        return ko.utils.arrayFilter(self.Rows(), function (user) {
            return user.IsSelected();
        });
    });
    
    self.IsAllSelected = ko.computed({
        read: function () {
            var isAllSelected = true;
            ko.utils.arrayForEach(self.Rows(), function (row) {
                isAllSelected = isAllSelected && row.IsSelected();
            });
            return isAllSelected;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.Rows(), function (row) {
                row.IsSelected(value);
            });
        },
        owner: self
    });
}
/*
function GroupRowViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();
    
    self.IsSelected = ko.observable();
    
    ko.mapping.fromJS(serverModel, {}, self);

    self.EditGroupUrl = ko.computed(function() {
        return window.actions.group.EditGroupUrl.replace('id', self.Id());
    });
}
*/