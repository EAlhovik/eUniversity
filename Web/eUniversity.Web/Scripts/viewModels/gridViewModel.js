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
        return ko.utils.arrayFilter(self.Rows(), function (row) {
            return row.IsSelected();
        });
    });
    
    self.IfAllSelected = ko.computed({
        read: function () {
            var ifAllSelected = true;
            ko.utils.arrayForEach(self.Rows(), function (row) {
                ifAllSelected = ifAllSelected && row.IsSelected();
            });
            return ifAllSelected;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.Rows(), function (row) {
                row.IsSelected(value);
            });
        },
        owner: self
    });
}