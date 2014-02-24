function SemesterViewModel(serverModel) {
    var self = this;
    self.IsActive = ko.observable(false);
    self.IsCompleted = ko.observable(false);

    self.Subjects = ko.observableArray();
    self.Sequential = ko.observable();
    
    self.Title = ko.computed(function () {
        return 'Семестр ' + self.Sequential();
    });

    var mappingOverride =
    {
        'Subjects':
        {
            create: function (options) {
                return createSubject(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);

    self.SelectedSubjects = ko.computed(function () {
        return ko.utils.arrayFilter(self.Subjects(), function (row) {
            return row.IsSelected();
        });
    });

    self.IfAllSelected = ko.computed({
        read: function () {
            var ifAllSelected = true;
            ko.utils.arrayForEach(self.Subjects(), function (row) {
                ifAllSelected = ifAllSelected && row.IsSelected();
            });
            return ifAllSelected;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.Subjects(), function (row) {
                row.IsSelected(value);
            });
        },
        owner: self
    });

    self.AddNewSubject = function () {
        self.Subjects.push(createSubject(null));
    };

    self.Remove = function (row) {
        if (row.Id()) {
//            remove({ viewModels: [ko.mapping.toJS(row)] });
        } else {
            self.Rows.remove(row);
        }
    };
    
    function createSubject(data) {
        return new window.SubjectViewModel(data);
    }

    self.select2 = {
        width: 200,
        id: function(item) {
            return item.Id;
        },
        formatResult: function(current) {
            return current.Text;
        },
        formatSelection: function(current) {
            return current.Text;
        },
        multiple: false,
        minimumInputLength: 0,
        query: function (query) {
            $.ajax("/Loockup/GetSubjects", {
                data: {
                    term: query.term
                },
                dataType: "json"
            }).done(function (data) {
                data = data || [];
                data.push({ Id: query.term + window.constants.SubjectIdPrefix, Text: query.term });
                query.callback({ results: data });
            });
        },
        initSelection: function(element, callback) {
            var id = $(element).val();
            if (id !== "") {
                var data = self.select2.loadElement(id);
                callback(data);
            }
        },
        loadElement: function(id) {
            var res;
            $.ajax({
                url: window.actions.curriculum.GetSubject,
                data: { id: id },
                async: false,
                success: function(data) {
                    res = data;
                    return data;
                }
            });
            return res;
        }
    };
    
}