app.controller("NewPropertyController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (Property) => {

            $http.post("/api/properties/", Property).then(function () {
                $location.path(`/properties`);
            }).catch((err) => {
                console.log("error adding new property", err);
            });
        };
    }
])