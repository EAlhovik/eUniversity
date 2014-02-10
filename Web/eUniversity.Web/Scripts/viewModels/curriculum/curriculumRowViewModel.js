function CurriculumRowViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.DateOfEnactment = ko.observable();
    self.SpecializatoinName = ko.observable();
    
    self.IsSelected = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);
    
    self.EditCurriculumUrl = ko.computed(function () {
        return window.actions.curriculum.CurriculumGridUrl.replace('id', self.Id());
    });
}