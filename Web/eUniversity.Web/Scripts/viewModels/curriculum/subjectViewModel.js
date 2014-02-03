function SubjectViewModel(serverModel) {
    var self = this;
    self.Subject = ko.observable();
    self.Assignee = ko.observable();
    self.SubjectType = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);
    
    self.SubjectNameDisplay = ko.computed(function () {
        if (self.Subject() != null) {
            return self.Subject().Text();
        }
        return '';
    });
    
    self.SubjectTypeDisplay = ko.computed(function() {
        switch (self.SubjectType()) {
            case 'CourseWork':
                return 'Курсовая работа';
            case 'Lecture':
                return 'Лекционные занятия';
            case 'CourseProject':
                return 'Курсовой проект';
            default:
                return '';
        }
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
        showModal({ viewModel: self })
        .done(function (result) {
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