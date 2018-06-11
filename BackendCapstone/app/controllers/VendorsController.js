app.controller("VendorsController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get("api/vendors/").then(function (result) {
            $scope.vendors = result.data;
        });

        $scope.viewVendorDetail = (vendorId) => {
            $location.path(`/vendors/${vendorId}`);
        };

        $scope.addNewVendor = () => {
            $location.path(`/vendors/new`);
        };

    }
]);