app.controller("EditPropertyController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`/api/properties/${$routeParams.id}`).then(function (result) {
            $scope.property = result.data;
        });

        $scope.updateProperty = (property) => {
            $http.put(`/api/properties/${$routeParams.id}`, property).then((result) => {
                $location.path(`/properties/`);
            })
        }

        $http.get("api/vendors/").then(function (result) {
            $scope.vendors = result.data;
        });

        $http.get("api/managers/").then(function (result) {
            $scope.managers = result.data;
        });

        $scope.back = () => {
            $location.path(`/properties`);
        };
    }
]);