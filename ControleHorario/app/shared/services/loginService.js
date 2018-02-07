(function () {
    'use strict';

    angular
        .module('app')
        .factory('loginService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.login = function (email, senha) {
                var deferred = $q.defer();
                $http.get('/Colaborador/Login/', {Email: email, Senha: senha}).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };
            return service;
        }]);
})();