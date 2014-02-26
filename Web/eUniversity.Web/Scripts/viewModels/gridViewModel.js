function GridViewModel(serverModel) {
    var self = this;
    self.Rows = ko.observableArray();

    var mappingOverride =
    {
        "Rows":
        {
            create: function (options) {
                return createObject(options.data);
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
        self.Rows.push(createObject(null));
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
            url: getUrl('RemoveUrl'),
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
            url: getUrl('SaveUrl'),
            type: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: success,
            complete: function (param1, status) {
            }
        });
    }

    function createObject(data) {
        return eval('new ' + serverModel.ViewModel + '(data, save)');
    }

    self.select2 = {
        width: 200,
        id: function (item) {
            return item.Id;
        },
        formatResult: function (current) {
            return current.Text;
        },
        formatSelection: function (current) {
            return current.Text;
        },
        multiple: false,
        ajax: {
            data: function (term) {
                return {
                    term: term
                };
            },
            url: getUrl('GetSelectedItemsUrl'),
            results: function (data) {
                return { results: data };
            }
        },
        initSelection: function (element, callback) {
            var id = $(element).val();
            if (id !== "") {
                var data = self.select2.loadElement(id);
                callback(data);
            }
        },
        loadElement: function (id) {
            var res;
            $.ajax({
                url: getUrl('GetSelectedItemUrl'),
                data: { id: id },
                async: false,
                success: function (data) {
                    res = data;
                    return data;
                }
            });
            return res;
        }
    };

    function getUrl(name) {
        if (window.actions[serverModel.Object] && window.actions[serverModel.Object][name]) {
            return window.actions[serverModel.Object][name];
        }
        return '';
    }
}