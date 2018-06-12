app.controller("PastEmergencyReportController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get("api/properties/").then(function (result) {
            $scope.properties = result.data;
        });

        $scope.back = () => {
            $location.path(`/emergencyreports`);
        };
    }
]);