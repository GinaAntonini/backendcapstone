app.controller("PropertiesController", function ($location, $http, $rootScope, $scope) {

    $scope.viewAllProperties = () => {
        $location.path(`/properties/viewproperties`);
    }

    $scope.addNewProperty = () => {
        $location.path(`/properties/new`);
    };

});