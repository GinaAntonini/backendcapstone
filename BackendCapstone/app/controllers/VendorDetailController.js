app.controller("VendorDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`/api/vendors/${$routeParams.id}`).then(function (result) {
            $scope.vendor = result.data;
        });

        $scope.back = () => {
            $location.path(`/vendors`);
        };

        $scope.edit = (vendorId) => {
            $location.path(`/vendors/edit/${vendorId}`);
        };

    }
]);