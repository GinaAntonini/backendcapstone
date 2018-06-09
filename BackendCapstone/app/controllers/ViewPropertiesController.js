app.controller("ViewPropertiesController", function ($location, $http, $rootScope, $scope) {

    $http.get("api/properties/").then(function (result) {
        $scope.properties = result.data;
    });

    $scope.viewPropertytDetail = (propertyId) => {
        $location.path(`/properties/${propertyId}`);
    };
});
