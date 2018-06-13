var app = angular.module("BackendCapstone", ["ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/index.html",
            controller: "HomeController"
        })
        .when("/properties",
        {
            templateUrl: "/app/partials/properties.html",
            controller: "PropertiesController"
        })
        .when("/properties/new",
        {
            templateUrl: "/app/partials/new_property.html",
            controller: "NewPropertyController"
        })
        .when("/properties/viewproperties",
        {
            templateUrl: "/app/partials/view_properties.html",
            controller: "ViewPropertiesController"
        })
        .when("/properties/search",
        {
            templateUrl: "/app/partials/search_properties.html",
            controller: "SearchPropertiesController"
        })
        .when("/properties/:id",
        {
            templateUrl: "/app/partials/property_detail.html",
            controller: "PropertyDetailController"
        })
        .when("/vendors",
        {
            templateUrl: "/app/partials/vendors.html",
            controller: "VendorsController"
        })
        .when("/vendors/new",
        {
            templateUrl: "/app/partials/new_vendor.html",
            controller: "NewVendorController"
        })
        .when("/vendors/:id",
        {
            templateUrl: "/app/partials/vendor_detail.html",
            controller: "VendorDetailController"
        })
        .when("/vendors/vendorsbyfieldofwork/:id",
        {
            templateUrl: "/app/partials/vendor_by_fieldofwork.html",
            controller: "VendorByFieldOFWorkController"
        })
        .when("/emergencyreports",
        {
            templateUrl: "/app/partials/emergency_reports.html",
            controller: "EmergencyReportsController"
        })
        .when("/emergencyreports/new",
        {
            templateUrl: "/app/partials/new_emergencyreport.html",
            controller: "NewEmergencyReportController"
        })
        .when("/emergencyreports/past",
        {
            templateUrl: "/app/partials/past_emergencyreports.html",
            controller: "PastEmergencyReportController"
        })
}]);