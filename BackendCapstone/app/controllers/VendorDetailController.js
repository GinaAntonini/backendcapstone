app.controller("VendorDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`/api/vendors/${$routeParams.id}`).then(function (result) {
            $scope.vendor = result.data;
        });

        $scope.back = () => {
            $location.path(`/vendors`);
        };

        $scope.edit = (vendor) => {
            $http.put("/api/vendors/", vendor).then(function () {
                $location.path(`/vendors/:id`);
            }).catch((err) => {
                console.log("error updating vendor", err);
            });
        };
    }
]);