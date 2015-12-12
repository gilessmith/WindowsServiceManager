

function Tag(text, isEditable, service) {
    var self = this;

    self.text = ko.observable(text);
    self.isEditable = ko.observable(isEditable);
    self.service = service;

    self.save = function () {
        self.isEditable(false);
        $.post(ajaxUrls.serviceTagging.generateAddTagUrl(self.service.serviceId, self.text()));
    }

    self.handleKeyPress = function(tag, evt) {
        if (evt.keyCode == 27) {
            self.isEditable(false);
            self.service.removeTag(self);
        }
    }
}