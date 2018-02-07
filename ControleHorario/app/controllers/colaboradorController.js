(function () {
    'use strict';

    angular
        .module('app')
        .controller('colaboradorCtrl', ['$scope', 'colaboradorService', 'Colaboradores',
            function ($scope, colaboradorService ,Colaboradores) {
                $scope.colaboradores = {};

                if (!Colaboradores) {
                    getColaboradores();
                } else {
                    $scope.colaboradores = Colaboradores;
                };

                function getColaboradores() {
                    colaboradorService.getColaboradores().then(function (result) {
                        $scope.colaboradores = result;
                    });
                };

                $scope.deleteColaborador = function (id) {
                    colaboradorService.deleteColaborador(id).then(function () {
                        alert('Colaborador excluído com sucesso');
                        getColaboradores();
                    }, function () {
                        alert('Erro ao tentar excluir colaborador');
                    });
                };
            }])
        .controller('addColaboradorCtrl', ['$scope', 'colaboradorService', '$location',
            function ($scope, colaboradorService, $location) {
                $scope.addColaborador = function (colaborador) {
                    colaboradorService.addColaborador(colaborador).then(function () {
                        //To do
                        //toastr.success('Colaborador cadastrado com sucesso');
                        alert('Colaborador cadastrado com sucesso');

                        $location.path('/Colaboradores');
                    }, function () {
                        alert('Não foi possível cadastrar colaborador')
                        //toastr.error('Não foi possível cadastrar colaborador');
                    })
                };
            }])
        .controller('updateColaboradorCtrl', ['$scope', 'colaboradorService', '$location', 'Colaborador', '$routeParams',
        function ($scope, colaboradorService, $location, Colaborador, $routeParams) {
                $scope.colaborador = {};

                if (!Colaborador) {
                    colaboradorService.getColaboradorById($routeParams.id).then(function (result) {
                        $scope.colaborador = result;
                    });
                } else {
                    $scope.colaborador = Colaborador;
                };

                $scope.updateColaborador = function (colaborador) {
                    colaboradorService.updateColaborador(colaborador).then(function () {
                        alert('Cadastro atualizado com sucesso');
                        $location.path('/Colaboradores');
                    }, function () {
                        alert('Não foi possível atualizar colaborador');
                    })
                };
            }]);
                
})();
