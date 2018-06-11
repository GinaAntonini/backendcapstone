app.controller("NewVendorController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (Vendor) => {

            $http.post("/api/vendors/", Vendor).then(function () {
                $location.path(`/vendors`);
            }).catch((err) => {
                console.log("error adding new vendor", err);
            });
        };
    }
])