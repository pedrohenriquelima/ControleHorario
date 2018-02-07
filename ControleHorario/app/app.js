(function () {
    'use strict';
    angular.module('app', ['ngRoute', 'ds.clock', 'webcam'])
        .config(['$routeProvider', '$locationProvider',
            function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
                $routeProvider
                .when('/', {
                    controller: 'cargaHorariaCtrl',
                    templateUrl: '/app/templates/CargaHoraria/CargaHoraria.html'                    
                })
                .when('/Home', {
                    controller: 'cargaHorariaCtrl',
                    templateUrl: '/app/templates/CargaHoraria/CargaHoraria.html'
                })
                .when('/GradeHorarios', {
                    controller: 'gradeHorariosCtrl',
                    templateUrl: '/app/templates/CargaHoraria/GradeHorarios.html'
                })
                .when('/Colaboradores', {
                    controller: 'colaboradorCtrl',
                    templateUrl: '/app/templates/Colaborador/Colaboradores.html',
                    resolve: {
                        Colaboradores: function (colaboradorService, $route) {
                            colaboradorService.getColaboradores().then(function (result) {
                                return result;
                            });
                        }
                    }   
                })
                .when('/AddColaborador', {
                    controller: 'addColaboradorCtrl',
                    templateUrl: '/app/templates/Colaborador/AddColaborador.html'
                })
                .when('/UpdateColaborador/:id', {
                    controller: 'updateColaboradorCtrl',
                    templateUrl: '/app/templates/Colaborador/UpdateColaborador.html',
                    resolve: {
                        Colaborador: ['$route', 'colaboradorService', function ($route, colaboradorService) {
                            var _id = $route.current.params.id;
                            colaboradorService.getColaboradorById(_id).then(function (result) {
                                return result;
                            });
                        }]
                    }
                })
                .when('/CargaHoraria/:id?', {
                    controller: 'cargaHorariaCtrl',
                    templateUrl: '/app/templates/CargaHoraria/CargaHoraria.html',
                    resolve: {
                        Colaborador:  ['$route', 'colaboradorService', function ($route, colaboradorService) {
                            var _id = $route.current.params.id;
                            if (!_id) {
                                return colaboradorService.getColaboradorById(_id).then(function (result) {
                                    return result;
                                });
                            }
                            return null;
                        }]
                    }
                })
                .when('/RegistrarHora/:id/:tipoHora', {
                    controller: 'registrarHoraCtrl',
                    templateUrl: '/app/templates/CargaHoraria/RegistrarHora.html',
                    resolve: {
                        Colaborador: ['$route', 'colaboradorService', function ($route, colaboradorService) {
                            var _id = $route.current.params.id;
                            return colaboradorService.getColaboradorById(_id).then(function (result) {
                                return result;
                            });
                        }]
                    }
                })
        }]);
})();