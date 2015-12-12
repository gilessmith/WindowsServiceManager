
function ServiceRow(displayName, serviceId, statusIcon, statusDisplayName, statusRowClass, actions, tags, eventMessenger) {
    var self = this;

    self.displayName = ko.observable(displayName);
    self.serviceId = serviceId;
    self.statusIcon = ko.observable(statusIcon);
    self.statusDisplayName = ko.observable(statusDisplayName);
    self.statusRowClass = ko.observable(statusRowClass);
    self.eventMessenger = eventMessenger;
    self.actions = ko.observableArray();
    self.tags = ko.observableArray($.map(tags, function (tag) { return new Tag(tag, false, self); }));

    self.setActions = function (actions) {
        self.actions.removeAll();
        self.actions(actions);
        $.each(actions, function (i, a) {
            a.setServiceRow(self);
        });
    }
    self.setActions(actions);

    self.createActionEvent = function (action) {
        var message = new ActionEventMessage(self.eventMessenger, self.displayName(), action.name());
        self.eventMessenger.addEventMessage(message);
        return message;
    }

    self.updateStatus = function (updatedServiceRowData) {
        self.setActions(mapper.createServiceActionsFromData(updatedServiceRowData));
        self.statusIcon(updatedServiceRowData.StatusIconClass);
        self.statusDisplayName(updatedServiceRowData.StatusDisplayName);
        self.statusRowClass(updatedServiceRowData.StatusRowClass);
    }

    self.removeTag = function (tagToRemove) {
        self.tags.remove(tagToRemove);

        $.post(ajaxUrls.serviceTagging.generateRemoveTagUrl(self.serviceId, tagToRemove.text()));
    }
    
    self.addEditableTag = function () {
        var tagToAdd = new Tag('', true, self);
        self.tags.push(tagToAdd);
        $('.newTagTextBox').focus();
    }

    self.hasAllTags = function(filterTags) {
        var hasAllTags = true;

        $.each(filterTags, function(i, t) {
            hasAllTags = hasAllTags && self.tags().find(function(element) { return element.text().toUpperCase() === t.text().toUpperCase(); }) ;
        });

        return hasAllTags;
    }
}
