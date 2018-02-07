(function () {
    'use strict';

    angular
        .module('app')
        .factory('cargaHorariaService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getCargaHoraria = function () {
                var deferred = $q.defer();
                $http.get('/CargaHoraria/getListCargaHoraria').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getCargaHorariaById = function (id) {
                var deferred = $q.defer();
                $http.get('/CargaHoraria/getCargaHoraria/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getCargaHorariaByColaboradorId = function (colaboradorId) {
                var deferred = $q.defer();
                $http.get('/CargaHoraria/getCargaHorariaColaborador/' + colaboradorId).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addCargaHoraria = function (cargaHoraria) {
                var deferred = $q.defer();
                $http.post('/CargaHoraria/AddCargaHoraria', cargaHoraria).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.updateCargaHoraria = function (cargaHoraria) {
                var deferred = $q.defer();
                $http.post('/CargaHoraria/UpdateCargaHoraria', cargaHoraria).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.deleteCargaHoraria = function (id) {
                var deferred = $q.defer();
                $http.post('/CargaHoraria/DeleteCargaHoraria', { idCargaHoraria: id }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };
            return service;

        }]);
})();