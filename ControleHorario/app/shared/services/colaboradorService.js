(function () {
    'use strict';

    angular
        .module('app')
        .factory('colaboradorService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getColaboradores = function (result) {
                var deferred = $q.defer();
                $http.get('/Colaborador/getListColaboradores').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getColaboradorById = function (id) {
                var deferred = $q.defer();
                $http.get('/Colaborador/getColaborador/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getColaboradorByMatricula = function (matricula) {
                var deferred = $q.defer();
                $http.get('/Colaborador/getColaboradorByMatricula/' + matricula).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addColaborador = function (colaborador) {
                var deferred = $q.defer();
                $http.post('/Colaborador/AddColaborador', colaborador).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.updateColaborador = function (colaborador) {
                var deferred = $q.defer();
                $http.post('/Colaborador/UpdateColaborador', colaborador).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.deleteColaborador = function (id) {
                var deferred = $q.defer();
                $http.post('/Colaborador/DeleteColaborador', { idColaborador: id }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            return service;
        }]);
})();