app.controller("VendorByFieldOfWorkController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`api/vendors?type=${$routeParams.id}`).then(function (result) {
            $scope.vendors = result.data;
        });

        $scope.viewVendorDetail = (vendorId) => {
            $location.path(`/vendors/${vendorId}`);
        };
    }]);