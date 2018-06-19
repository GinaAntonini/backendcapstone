app.controller("NewEmergencyReportController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (EmergencyReport) => {

            $http.post("/api/emergencyreports/", EmergencyReport).then(function () {
                $location.path(`/emergencyreports`);
            }).catch((err) => {
                console.log("error adding new emergency report", err);
            });
        };

        $http.get("api/properties/").then(function (result) {
            $scope.properties = result.data;
        });

        $http.get("api/managers/").then(function (result) {
            $scope.managers = result.data;
        });

        $scope.back = () => {
            $location.path(`/emergencyreports`);
        };
    }
])