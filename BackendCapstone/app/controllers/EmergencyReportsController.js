app.controller("EmergencyReportsController", function ($location, $http, $rootScope, $scope) {

    $scope.viewPastReports = () => {
        $location.path(`/emergencyreports/past`);
    }

    $scope.addNewReport = () => {
        $location.path(`/emergencyreports/new`);
    };
});