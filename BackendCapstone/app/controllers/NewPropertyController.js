app.controller("NewPropertyController", ["$routeParams", "$location", "$scope", "$http",
    function ($routeParams, $location, $scope, $http) {

        $scope.new = (Property) => {

            $http.post("/api/properties/", Property).then(function () {
                $location.path(`/properties`);
            }).catch((err) => {
                console.log("error adding new property", err);
            });
        };

        $http.get("api/vendortypes/").then(function (result) {
            $scope.vendorTypes = result.data;
        });

        $http.get("api/vendors/").then(function (result) {
            $scope.vendors = result.data;
        });

        $http.get("api/managers/").then(function (result) {
            $scope.managers = result.data;
        });

        $scope.back = () => {
            $location.path(`/properties`);
        };
    }
])