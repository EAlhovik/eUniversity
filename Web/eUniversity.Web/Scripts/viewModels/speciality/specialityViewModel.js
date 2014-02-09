function SpecialityViewModel(serverModel) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.Description = ko.observable();

    ko.mapping.fromJS(serverModel, {}, self);

    self.Save = function () {
        $.ajax({
            url: window.actions.speciality.SaveSpecialityUrl,
            type: "POST",
            data: JSON.stringify({ viewModel: ko.mapping.toJS(self) }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                window.location.href = window.actions.speciality.SpecialityGridUrl;
            }
        });
    };
}