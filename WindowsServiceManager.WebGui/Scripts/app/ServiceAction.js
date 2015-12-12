
function ServiceAction(icon, url, name, serviceId, expectedCompletionStatusId) {
    var self = this;

    self.icon = ko.observable(icon);
    self.url = ko.observable(url);
    self.name = ko.observable(name);
    self.serviceId = ko.observable(serviceId);
    self.serviceRow = null;
    self.expectedCompletionStatusId = expectedCompletionStatusId;

    self.setServiceRow = function (serviceRow) {
        self.serviceRow = serviceRow;
    }

    self.performAction = function () {
        var eventMessage = self.serviceRow.createActionEvent(self);
        $.post(ajaxUrls.serviceActions.generateServiceActionUrl(self.url() , self.serviceId()));
        self.pollUntilExpectedStatusReached(eventMessage);
    }

    self.pollUntilExpectedStatusReached = function (eventMessage, pollCount) {
        if (!pollCount) {
            pollCount = 1;
        }

        $.post(ajaxUrls.serviceDetails.generateServiceDetailUrl(self.serviceId()))
            .done(function (result) {
                if (result.StatusId == self.expectedCompletionStatusId) {
                    // Success the service has done what we expected
                    eventMessage.setComplete();
                    self.serviceRow.updateStatus(result);
                } else {
                    if (pollCount > 1000) { return; }

                    setTimeout(function () { self.pollUntilExpectedStatusReached(eventMessage, pollCount); }, 1000);
                }
            });
    }
}