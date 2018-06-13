app.controller("VendorByFieldOfWorkController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get("api/vendors/").then(function (result) {
            $scope.vendorTypes = result.data;
        });
}])