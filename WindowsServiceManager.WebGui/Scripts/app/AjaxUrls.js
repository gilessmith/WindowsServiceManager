var ajaxUrls = {}

ajaxUrls.serviceDetails = function() {
    var ret = {}

    ret.serviceDetailsList = "/ServiceDetail/ListServices";

    ret.generateServiceDetailUrl = function(serviceId) {
        return "/ServiceDetail/GetServiceInfo/" + serviceId;
    }

    return ret;
}();

ajaxUrls.serviceActions = function() {
    var ret = {}

    ret.generateServiceActionUrl = function(actionMethodName, serviceId) {
        return "/ServiceAction/" + actionMethodName + "/" + serviceId;
    }

    return ret;
}();

ajaxUrls.serviceTagging = function() {
    var ret = {}

    ret.generateRemoveTagUrl = function (serviceId, tagText) {
        return "/ServiceTagging/RemoveTag/" + serviceId + "?tagText=" + tagText;
    }

    ret.generateAddTagUrl = function (serviceId, tagText) {
        return "/ServiceTagging/AddTag/" + serviceId + "?tagText=" + tagText;
    }

    return ret;
}();