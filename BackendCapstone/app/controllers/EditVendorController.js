app.controller("EditVendorController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`/api/vendors/${$routeParams.id}`).then(function (result) {
            $scope.vendor = result.data;
        });

        $scope.updateVendor = (vendor) => {
            $http.put(`/api/vendors/${$routeParams.id}`, vendor).then((result) => {
                $location.path(`/vendors/`);
            })
        }

        $http.get("api/vendortypes/").then(function (result) {
            $scope.vendorTypes = result.data;
        });

        $scope.back = () => {
            $location.path(`/vendors`);
        };
    }
]);


