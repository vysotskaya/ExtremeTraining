angular.module('wunderlistApp', ['ngResource', 'ui.router', 'dndLists', 'ngAnimate'])
    .config([
        '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('todoTasks', {
                    url: 'todolists/:id/todotasks',
                    templateUrl: '/Partials/TodoTasks',
                    controller: 'todoTaskController'
                })
                .state('todoTasks.detailsTask', {
                    url: '/:idTask',
                    templateUrl: '/Partials/DetailOfTodoTask',
                    controller: 'todoTaskController'
                });
        }
    ])
    .constant('WUNDERLIST_CONSTANTS', {
        'URL': 'http://localhost:53028'
    });