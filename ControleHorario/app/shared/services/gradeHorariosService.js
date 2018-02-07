(function () {
    'use strict';

    angular
        .module('app')
        .factory('gradeHorariosService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getGradeHorarios = function () {
                var deferred = $q.defer();
                $http.get('/GradeHorarios/getListGradeHorarios').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getGradeHorariosById = function (id) {
                var deferred = $q.defer();
                $http.get('/GradeHorarios/getGradeHorarios/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getGradeHorariosByColaboradorId = function (colaboradorId) {
                var deferred = $q.defer();
                $http.get('/GradeHorarios/getGradeHorariosColaborador/' + colaboradorId).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addGradeHorarios = function (gradeHorarios) {
                var deferred = $q.defer();
                $http.post('/GradeHorarios/AddGradeHorarios', gradeHorarios).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.updateGradeHorarios = function (gradeHorarios) {
                var deferred = $q.defer();
                $http.post('/GradeHorarios/UpdateGradeHorarios', gradeHorarios).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.deleteGradeHorarios = function (id) {
                var deferred = $q.defer();
                $http.post('/GradeHorarios/DeleteGradeHorarios', { idGradeHorarios: id }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };
            return service;

        }]);
})();