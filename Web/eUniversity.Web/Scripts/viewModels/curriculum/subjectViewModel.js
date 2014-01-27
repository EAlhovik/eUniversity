function SubjectViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.Query = function (query) {
        var data = { results: [] }, i, j, s;
        if (query.term != '') {
            for (i = 1; i < 5; i++) {
                s = "";
                for (j = 0; j < i; j++) { s = s + query.term; }
                data.results.push({ id: query.term + i, text: s });
            }
        }
        query.callback(data);
    };
}