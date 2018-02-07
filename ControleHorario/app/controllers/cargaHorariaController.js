(function () {
    'use strict';

    angular
        .module('app')
        .controller('cargaHorariaCtrl', ['$scope', 'cargaHorariaService',
            function ($scope, cargaHorariaService) {
                $scope.cargaHoraria = [];
                $scope.tipoHora = "Entrada";
                $scope.onError = function (err) {
                    alert('A Web cam não foi inciada corretamente')
                };

                getCargaHoraria();

                function getCargaHoraria() {
                    cargaHorariaService.getCargaHoraria().then(function (result) {
                        $scope.cargaHoraria = result;
                    });
                }
            }])
        .controller('registrarHoraCtrl', ['$scope', 'cargaHorariaService', '$routeParams', 'Colaborador',
            function ($scope, cargaHorariaService, $routeParams, Colaborador) {

                $scope.hora = {
                    TipoHora: $routeParams.tipoHora,
                    Dia: null,
                    HoraEntrada: null,
                    HoraSaida: null,
                    Intervalo: null
                };
            }]);
})();
