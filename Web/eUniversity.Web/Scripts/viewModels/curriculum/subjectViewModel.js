function SubjectViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.Query = function (query) {
        $.ajax("/Loockup/GetSubjects", {
            data: {
                term: query.term
            },
            dataType: "json"
        }).done(function (data) {
            data = data || [];
            data.push({ Id: '0', Text: query.term });
            query.callback({ results: ko.mapping.fromJS(data)() });
        });
        

    };

    self.Add = function() {
        self.modal.close(self);
    };
    
    self.Cancel = function () {
        self.modal.close();
    };
//    self.template = "AddSubject";
}
SubjectViewModel.prototype.template = "AddSubject";