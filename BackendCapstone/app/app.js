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
        .when("/properties/:id",
        {
            templateUrl: '/app/partials/property_detail.html',
            controller: 'PropertyDetailController'
        })
}]);