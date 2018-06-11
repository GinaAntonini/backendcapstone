app.controller("ViewPropertiesController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get("api/properties/").then(function (result) {
            $scope.properties = result.data;
        });

        $scope.viewPropertyDetail = (propertyId) => {
            $location.path(`/properties/${propertyId}`);
        };

    }
]);
