function SubjectViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Assignee = ko.observable();
    self.SubjectType = ko.observable();

    self.IsSelected = ko.observable();

    if (serverModel != null) {
        ko.mapping.fromJS(serverModel, {}, self);
    }
    
    self.select2ForSubjectType = {
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
        minimumInputLength: 0,
        query: function (query) {
            $.ajax(window.actions.curriculum.GetSubjectTypesUrl, {
                data: {
                    term: query.term
                },
                dataType: "json"
            }).done(function (data) {
                data = data || [];
//                data.push({ Id: query.term + window.constants.SubjectIdPrefix, Text: query.term });
                query.callback({ results: data });
            });
        },
        initSelection: function (element, callback) {
            var id = $(element).val();
            if (id !== "") {
                var data = self.select2ForSubjectType.loadElement(id);
                callback(data);
            }
        },
        loadElement: function (id) {
            var res;
            $.ajax({
                url: window.actions.curriculum.GetSubjectTypeUrl,
                data: { id: id },
                async: false,
                success: function (data) {
                    res = data;
                    return data;
                }
            });
            return res;
        }
    }
}