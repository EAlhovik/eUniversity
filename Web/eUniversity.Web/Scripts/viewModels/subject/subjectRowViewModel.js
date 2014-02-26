function SubjectRowViewModel(serverModel) {
    var self = this;
    self.IsSelected = ko.observable();
    
    self.Id = ko.observable();
    self.SubjectName = ko.observable();
    self.SemesterNumber = ko.observable();
    self.CurriculumName = ko.observable();
    self.SpecializationName = ko.observable();
    self.Themes = ko.observableArray();

    ko.mapping.fromJS(serverModel, {}, self);
    
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
        multiple: true,
        display: function (value, sourceData,wqe,re) {
            var $el = $('#list'),
                checked, html = '';
            if (!value) {
                $el.empty();
                return;
            }

            checked = $.grep(sourceData, function (o) {
                return $.grep(value, function (v) {
                    return v == o.value;
                }).length;
            });

            $.each(checked, function (i, v) {
                html += '<li>' + $.fn.editableutils.escape(v.text) + '</li>';
            });
            if (html) html = '<ul>' + html + '</ul>';
            $el.html(html);
        },
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
                data: { ids: id },
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
        if (window.actions['subject'] && window.actions['subject'][name]) {
            return window.actions['subject'][name];
        }
        return '';  
    }
}