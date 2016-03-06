var app = angular.module('wunderlistApp', ['ngResource']);

//app.config(function($stateProvider, $urlRouterProvider) {
//    debugger;
//	$urlRouterProvider.otherwise('/');

//    $stateProvider
//        .state('', {
//            url: '/',
//            views: {
//                'lists': {
//                    templateUrl: '/Home/About'
//                },
//                'tasks': {
//                    //templateUrl: '~/Views/Wunderlist/Partials/tasks.html'
//                    template: '<h2>Hui</h2>'
//                }
//            }
//        });
//});

app.controller('wunderlistAppController',['todoListService', '$scope', '$http', function (todoListService, $scope, $http) {
    //$scope.lists = [{ "TodoListName": "first", "Id": "1", "UserProfileRefId": "1" },
    //               { "TodoListName": "second", "Id": "2", "UserProfileRefId": "1" },
    //               { "TodoListName": "third", "Id": "3", "UserProfileRefId": "1" }];
    //$scope.lists = todoListService.getTodolists();
    $scope.getTodoLists = function() {
        todoListService.getTodolists(function (response) {
            debugger;
            $scope.lists = response;
        });
    };
    $scope.getTodoLists();

    $scope.selectTodoList = function (listId, listName) {
        $scope.selectedTodoListName = listName;
    }

    $scope.todoList = {};
    $scope.addNewTodoList = function (userId) {
        debugger;
        $scope.todoList.UserProfileRefId = userId;
        $http({
            url: 'http://localhost:53028/api/TodoList/Post',
            method: 'POST',
            data: { 'Id': 0, 'UserProfileRefId': $scope.todoList.UserProfileRefId, 'TodoListName': $scope.todoList.TodoListName }
        }).then(function (response) {
            debugger;
            console.log(response);
            $scope.lists.push({ TodoListName: $scope.todoList.TodoListName, Id: response });
            console.log($scope.lists);
        });
        //$http.post('http://localhost:53028/api/TodoList/Post', )
        //todoListService.addTodolist($scope.todoList, function (response) {
        //    debugger;
        //    console.log(response);
        //});
        //$scope.getTodoLists();
        
    }
}]);