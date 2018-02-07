(function () {
    'use strict';
    angular
        .module('app')
        .controller('loginCtrl', ['$scope','loginService',
            function ($scope, loginService) {
                $scope.autenticado = false;
                $scope.colaborador = {};

                $scope.dadosLogin = {
                    Email: '',
                    Senha: ''
                };

                $scope.Login = function () {
                    loginService.login($scope.loginData).then(function (result) {
                        if (result.Email != null) {
                            $scope.autenticado = true;
                            $scope.colaborador = result;
                        } else {
                            alert('Dados de login inválidos');
                        }
                    });
                };
            }]);
})();
