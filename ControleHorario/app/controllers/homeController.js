(function () {
    'use strict';

    angular
        .module('app')
        .controller('homeCtrl', ['$scope', 'colaboradorService', 'Colaborador', '$location',
                function ($scope, colaboradorService, $routeParams, Colaborador, $location) {
                    $scope.colaborador = {};

                    //if (!Colaborador) {
                    //    $locatio.path('#/Login');
                    //} else {
                    //    $scope.colaborador = Colaborador;
                    //};

                    $scope.colaborador = Colaborador;
                }]);
})();
