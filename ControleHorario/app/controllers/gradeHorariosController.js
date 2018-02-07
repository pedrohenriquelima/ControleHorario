(function () {
    'use strict';

    angular
        .module('app')
        .controller('gradeHorariosCtrl', ['$scope', '$q','gradeHorariosService',
            function ($scope, $q, gradeHorariosService) {
                $scope.gradeHorarios = [];
                $scope.TotalHoras = null;

                getGradeHorarios();

                function getGradeHorarios() {
                    gradeHorariosService.getGradeHorarios().then(function (result) {
                        for (var i in result) {
                            var _horaEntrada = convertTimeSpan(result[i]['HoraEntrada']);
                            var _horaSaida = convertTimeSpan(result[i]['HoraSaida']);
                            var _intervalo = convertTimeSpan(result[i]['Intervalo']);
                            var _total = $scope.totalizarHoras(_horaEntrada, _horaSaida, _intervalo);

                            $scope.gradeHorarios.push({
                                Id: result[i]['DiaSemana'],
                                DiaSemana: result[i]['DiaSemana'],
                                HoraEntrada: _horaEntrada,
                                HoraSaida: _horaSaida,
                                Intervalo: _intervalo,
                                Total: _total
                            });
                            $scope.TotalHoras += _total;
                        };
                        $scope.TotalHoras += _total;
                    }).catch(function () {
                        alert('Não foi possível buscar grade de horários')
                    });
                };

                function convertTimeSpan(valorTimeSpan) {
                    if (!valorTimeSpan) {
                        return null;
                    };

                    var _dateTime = new Date(parseInt(valorTimeSpan.substr(6)));
                    return _dateTime;
                };

                function toUTCDate (date) {
                    var _utc = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds());
                    return _utc;
                };

                function millisToUTCDate (millis) {
                    return toUTCDate(new Date(millis));
                };

                $scope.totalizarHoras = function (horaEntrada, horaSaida, intervalo) {
                    var _horaEntrada = toUTCDate(horaEntrada);
                    var _horaSaida = toUTCDate(horaSaida);

                    var minutosIntervalo = intervalo.getMinutes() * 60000;

                    if (minutosIntervalo == 0) {
                        return 0
                    };

                    return (_horaSaida.getTime() - minutosIntervalo) - _horaEntrada.getTime();
                };

                $scope.updateGradeHorarios = function () {
                    var promises = [];

                    for (var i in $scope.gradeHorarios) {
                        var gradeHorario = $scope.gradeHorarios[i];
                        gradeHorario = {
                            Id: gradeHorario.Id,
                            DiaSemana: gradeHorario.DiaSemana,
                            HoraEntrada: gradeHorario.HoraEntrada,
                            HoraSaida: gradeHorario.HoraSaida,
                            Intervalo: gradeHorario.Intervalo
                        };
                        promises.push(gradeHorariosService.updateGradeHorarios(gradeHorario));
                    };
                    $q.all(promises).then(function () {
                        console.log('Grade atualizada com sucesso');
                    }).catch(function () {
                        console.log('Não foi possível atualizar a grade');
                    });
                };
        }]);    
})();
