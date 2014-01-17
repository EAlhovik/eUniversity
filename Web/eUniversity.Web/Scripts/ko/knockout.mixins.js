function addValidation(self) {
    self.errors = ko.validation.group(self);
    self.validateable = ko.validatedObservable(self);
    self.isValid = function () {
        return this.validateable.isValid();
    };
    self.validate = function () {
        return !this.isValid() ? (this.errors.showAllMessages(), false) : true;
    };
    self.showServerErrors = function(a) {
        if (a.errors)
            for (var e in a.errors) {
                var f = this[e];
                if (f && f.customError)
                    f.customError(a.errors[e]);
                else if (DEBUG)
                    throw Error("View model must have observable '" + e + "' which has customError enabled");
            }
    };
}