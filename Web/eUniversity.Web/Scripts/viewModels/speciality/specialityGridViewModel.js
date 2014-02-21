function SpecialityGridViewModel(serverModel) {
    var self = this;
    self.Rows = ko.observableArray();

    var mappingOverride =
    {
        "Rows":
        {
            create: function (options) {
                return new window.SpecialityRowViewModel(options.data, save);
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

    self.AddNewRow = function () {
        self.Rows.push(new window.SpecialityRowViewModel(null, save));
    };

    self.Remove = function (row) {
        if (row.Id()) {
            remove({ viewModels: [ko.mapping.toJS(row)] });
        } else {
            self.Rows.remove(row);
        }
    };

    self.RemoveSelected = function () {
        var data = { viewModels: ko.mapping.toJS(self.SelectedRows) };

        remove(data);
    };

    self.SaveSelected = function () {
        var data = { viewModels: ko.mapping.toJS(self.SelectedRows) };
        save(data);
    };

    function remove(data, success) {
        $.ajax({
            url: '/Speciality/Remove',
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: success,
            complete: function (param1, status) {
            }
        });
    }

    function save(data, success) {
        $.ajax({
            url: '/Speciality/Save',
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: success,
            complete: function (param1, status) {
            }
        });
    }
}