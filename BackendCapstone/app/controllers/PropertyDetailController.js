﻿app.controller("PropertyDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.refuse = false;

        $http.get(`/api/properties/${$routeParams.id}`).then(function (result) {
            $scope.property = result.data;
        });

        $scope.back = () => {
            $location.path(`/properties`);
        };
    }
]);