

function EventMessenger() {
    var self = this;

    self.eventMessages = ko.observableArray();

    self.addEventMessage = function (eventMessage) {
        self.eventMessages.push(eventMessage);
    }

    self.removeMessage = function (message) {
        self.eventMessages.remove(message);
    }

    self.hideEventMessage = function (elem) {
        if (elem.nodeType === 1) {
            $(elem).delay(2000).fadeOut(2000, function () { $(elem).remove(); });
        }
    }
}

function ActionEventMessage(eventMessenger, serviceName, actionName) {
    var self = this;

    self.serviceName = ko.observable(serviceName);
    self.actionName = ko.observable(actionName);
    self.isComplete = ko.observable(false);
    self.eventMessenger = eventMessenger;

    self.text = ko.computed(function () {
        if (!self.isComplete()) {
            return "Service <em>'" + self.serviceName() + "'</em> is being " + self.actionName() + ".";
        } else {
            return "Service <em>'" + self.serviceName() + "'</em> has been " + self.actionName() + ".";
        }
    }, self);

    self.setComplete = function () {
        self.isComplete(true);
        self.eventMessenger.removeMessage(self);
    }
}

function EventMessage(text) {
    var self = this;

    self.text = ko.observable(text);
}
