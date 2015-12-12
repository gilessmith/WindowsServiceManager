

function FilterTag(text, isEditable) {
    var self = this;

    self.text = ko.observable(text);
    self.isEditable = ko.observable(isEditable);
}

function HomeViewModel() {
    var self = this;
    self.servicesInner = ko.observableArray();
    self.headers = ko.observableArray([
        { name: "", sort: function(a, b) { return a.displayName - b.displayName; }, direction: '', canSortBy: false },
        { name: "Name", sort: function(a, b) { return a.displayName() < b.displayName() ? -1 : 1; }, direction: 'asc', canSortBy: true },
        { name: "Status", sort: function(a, b) { return a.statusDisplayName() < b.statusDisplayName() ? -1 : 1; }, direction: '', canSortBy: true },
        { name: "Tags", sort: function(a, b) { return a.statusDisplayName() < b.statusDisplayName() ? -1 : 1; }, direction: '', canSortBy: true },
        { name: "", sort: function(a, b) { return a.displayName > b.displayName; }, direction: '', canSortBy: false }
    ]);

    self.filterText = ko.observable("");
    self.filterTags = ko.observableArray();
    self.eventMessenger = new EventMessenger();

    self.getData = function() {
        $.getJSON(ajaxUrls.serviceDetails.serviceDetailsList, function(data) {
            var mappedServices = $.map(data.WindowsServices, function(s) {
                var actions = mapper.createServiceActionsFromData(s);
                return new ServiceRow(s.DisplayName, s.ServiceId, s.StatusIconClass, s.StatusDisplayName, s.StatusRowClass, actions, s.Tags, self.eventMessenger);
            });
            self.servicesInner(mappedServices);
        });
    }

    self.services = ko.computed(function () {
        var servicesToFilter = self.servicesInner();
        if (self.filterTags().length > 0) {
            servicesToFilter = ko.utils.arrayFilter(servicesToFilter, function (item) {
                return item.hasAllTags(self.filterTags());
            });
        }
        if (self.filterText()) {
            servicesToFilter = ko.utils.arrayFilter(servicesToFilter, function (item) { return item.displayName().toLowerCase().indexOf(self.filterText().toLowerCase()) > -1; });
        }
        return servicesToFilter;
    });

    self.getData();

    self.sort = function(headerValue) {
        if (!headerValue.canSortBy) {
            return;
        }

        var direction = headerValue.direction;
        $.each(self.headers(), function(h) { h.direction = ''; });
        headerValue.direction = direction == 'asc' ? 'desc' : 'asc';

        if (headerValue.direction == 'desc') {
            self.servicesInner.sort(function(a, b) { return -1 * headerValue.sort(a, b); });
        } else {
            self.servicesInner.sort(function(a, b) { return headerValue.sort(a, b); });
        }
    }

    self.addFilterTag = function() {
        self.filterTags.push(new FilterTag('', true));
    }

    self.removeFilterTag = function(tagToRemove) {
        self.filterTags.remove(tagToRemove);
    }

    $('#filterByTag').tagit();

    var filterTags = $.url().param('filtertags');
    if (filterTags) {
        $.each(filterTags.split(","), function(i, tag) {
            self.filterTags.push(new FilterTag(tag, false));
            $('#filterByTag').tagit("createTag", tag);
        });
    }

    var filterText = $.url().param('filtertext');
    if (filterText) {
        self.filterText(filterText);
    }
    
    $('#filterByTag').tagit({
        afterTagAdded: function (event, ui) {
            self.filterTags.push(new FilterTag(ui.tagLabel, false));
        },
        afterTagRemoved: function (event, ui) {
            var tagText = ui.tagLabel.toUpperCase();
            var tagToRemove = self.filterTags().find(function (t) { return t.text().toUpperCase() == tagText; });
            self.filterTags.remove(tagToRemove);
        }
    });
}

var mapper = {};
mapper.createServiceActionsFromData = function (serviceData) {
    return $.map(serviceData.ServiceActions, function(action) {
        return new ServiceAction(action.ActionIconClass, action.ActionMethod, action.ActionDisplayName, serviceData.Name, action.ExpectedCompletionStatus);
    });
}

ko.applyBindings(new HomeViewModel());
