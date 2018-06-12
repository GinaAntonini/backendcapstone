app.controller("EditVendorController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`/api/vendors/${$routeParams.id}`).then(function (result) {
            $scope.property = result.data;
        });

        $scope.edit = (vendor) => {
            $http.put("/api/vendors/${id}/edit", vendor).then(function () {
                $location.path(`/vendors`);
            }).catch((err) => {
                console.log("error updating vendor", err);
            });
        };
    }
]);


