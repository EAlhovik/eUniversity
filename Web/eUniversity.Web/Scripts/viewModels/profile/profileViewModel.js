function ProfileViewModel(serverModel) {
    var self = this;
    
    self.Tabs = ko.observableArray([
        { Title: ko.observable('Basic Info'), IconClass: ko.observable('icon-edit green'), IsActive: ko.observable(true), Type: ko.observable('BasicProfile') },
        { Title: ko.observable('Settings'), IconClass: ko.observable('icon-cog purple'), IsActive: ko.observable(false), Type: ko.observable('Settings') },
        { Title: ko.observable('Password'), IconClass: ko.observable('icon-key blue'), IsActive: ko.observable(false), Type: ko.observable('ChangePassword') }
    ]);
    
    self.BasicProfile = ko.observable();
    self.Settings = ko.observable();
    self.ChangePassword = ko.observable();

    var mappingOverride =
    {
        "BasicProfile":
        {
            create: function (options) {
                return new window.BasicProfileViewModel(options.data);
            }
        },
        "Settings":
        {
            create: function (options) {
                return new window.SettingsViewModel(options.data);
            }
        },
        "ChangePassword":
        {
            create: function (options) {
                return new window.ChangePasswordViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);

    self.SelectTab = function(tab) {
        var activeTab = getActiveTab();
        
        self[activeTab.Type()]().IsActive(false);
        activeTab.IsActive(false);
        tab.IsActive(true);
        self[tab.Type()]().IsActive(true);
    };

    self.Save = function() {
        var activeTab = getActiveTab();
        $.ajax({
            url: '/Profile/Save',
            type: "POST",
            data: JSON.stringify({ viewModel: ko.mapping.toJS(self[activeTab.Type()]) }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                alert('data was successfully saved');
            },
            complete: function (param1, status) {
            }
        });
    };
    
    function getActiveTab() {
        var activeTab = ko.utils.arrayFirst(self.Tabs(), function (item) {
            return item.IsActive();
        });
        return activeTab;
    }
}