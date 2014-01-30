function SubjectViewModel(serverModel) {
    var self = this;
    self.Subject = ko.observable();
    self.SubjectType = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);
    self.DisplayName = ko.computed(function () {
        if (self.Subject() != null) {
            return self.Subject().Text();
        }
        return '';
    });
    
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

    self.ShowSubject = function() {
        showModal({ viewModel: new SubjectViewModel(ko.toJS(self)) })
        .done(function (result) {
            var data = ko.toJS(result);
            ko.mapping.fromJS(data, {}, self);
//            self.Subjects.push(result);
            console.log("Modal closed with result: " + result);
        })
        .fail(function () {
            console.log("Modal cancelled");
        });
    };

    self.Add = function() {
        self.modal.close(self);
    };
    
    self.Cancel = function () {
        self.modal.close();
    };
    //    self.template = "AddSubject";

    self.SubjectType.subscribe(function(val) {
        console.log(val);
    });
}
SubjectViewModel.prototype.template = "AddSubject";