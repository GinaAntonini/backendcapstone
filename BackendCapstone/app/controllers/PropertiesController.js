app.controller("PropertiesController", function ($location, $http, $rootScope, $scope) {

    $scope.viewAllProperties = () => {
        $location.path(`/properties/viewproperties`);
    }

    $scope.searchAllProperties = () => {
        $location.path(`/properties/search`);
    };

    $scope.addNewProperty = () => {
        $location.path(`/properties/new`);
    };

});