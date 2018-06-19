app.controller("PropertyDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.refuse = false;

        $http.get(`/api/properties/${$routeParams.id}`).then(function (result) {
            $scope.property = result.data;
        });

        $scope.viewVendorDetail = (vendorId) => {
            $location.path(`/vendors/${vendorId}`);
        };

        $scope.back = () => {
            $location.path(`/properties`);
        };

        $scope.edit = (propertyId) => {
            $location.path(`/properties/edit/${propertyId}`);
        };

        $http.get(`api/emergencyreports?type=${$routeParams.id}`).then(function (result) {
            $scope.emergencyreports = result.data;
        });
    }
]);