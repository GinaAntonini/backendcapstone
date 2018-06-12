app.controller("VendorsController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get("api/vendors/").then(function (result) {
            $scope.vendors = result.data;
            $scope.fieldOfWorks = result.data.map(function (vendor) { return vendor.FieldOfWork; }).filter(unique).sort();
        });

        $http.get(`/api/vendors/${$routeParams.id}`).then(function (result) {
            $scope.vendor = result.data;
        });

        $scope.viewVendorDetail = (vendorId) => {
            $location.path(`/vendors/${vendorId}`);
        };

        $scope.addNewVendor = () => {
            $location.path(`/vendors/new`);
        };

        $http.get("api/vendors/").then(function (result) {
            $scope.vendors = result.data;
        });

        function unique (value, index, self) {
            return self.indexOf(value) === index;
        }
    }
]);