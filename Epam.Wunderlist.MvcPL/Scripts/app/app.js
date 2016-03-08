var app = angular.module('wunderlistApp', ['ngResource', 'ui.router']);

app.controller('wunderlistAppController',['todoListService', '$scope', '$http', function (todoListService, $scope, $http) {
    //$scope.lists = [{ "TodoListName": "first", "Id": "1", "UserProfileRefId": "1" },
    //               { "TodoListName": "second", "Id": "2", "UserProfileRefId": "1" },
    //               { "TodoListName": "third", "Id": "3", "UserProfileRefId": "1" }];
    //$scope.lists = todoListService.getTodolists();
    $scope.getTodoLists = function() {
        todoListService.getTodolists(function (response) {
            $scope.lists = response;
        });
    };
    $scope.getTodoLists();

    $scope.selectTodoList = function (listId, listName) {
        $scope.selectedTodoListName = listName;
    }

    $scope.todoList = {};
    $scope.addNewTodoList = function (userId) {
        if ($scope.todoList.TodoListName == "") {
            return;
        }
        debugger;
        $scope.todoList.UserProfileRefId = userId;
        $http({
            url: 'http://localhost:53028/api/TodoList/Post',
            method: 'POST',
            data: { 'Id': 0, 'UserProfileRefId': $scope.todoList.UserProfileRefId, 'TodoListName': $scope.todoList.TodoListName }
        }).then(function (response) {
            debugger;
            console.log(response);
            $scope.lists.push({ TodoListName: $scope.todoList.TodoListName, Id: response, UserProfileRefId: $scope.todoList.UserProfileRefId });
            $scope.todoList.TodoListName = "";
            console.log($scope.lists);
        });
        //$http.post('http://localhost:53028/api/TodoList/Post', )
        //todoListService.addTodolist($scope.todoList, function (response) {
        //    debugger;
        //    console.log(response);
        //});
        //$scope.getTodoLists();
    }

    $scope.editedTodoList = {};

    $scope.prepareForEdit = function (listId) {
        angular.forEach($scope.lists, function(u, i) {
            if (u.Id === listId) {
                $scope.editedTodoList.TodoListName = $scope.lists[i].TodoListName;
                $scope.editedTodoList.Id = listId;
                $scope.editedTodoList.UserProfileRefId = $scope.lists[i].UserProfileRefId;
            }
        });
    };

    $scope.editTodoList = function () {
        if ($scope.editedTodoList.TodoListName == "") {
            return;
        }
        angular.forEach($scope.lists, function (u, i) {
            if (u.Id === $scope.editedTodoList.Id) {
                $scope.lists[i].TodoListName = $scope.editedTodoList.TodoListName;
            }
        });
    }

    $scope.deleteTodoList = function(listId) {
        angular.forEach($scope.lists, function (u, i) {
            if (u.Id === listId) {
                $scope.lists.splice(i, 1);
            }
        });
    }
}]);

app.controller('todoTaskController', ['$scope', '$stateParams', 'todoTaskService', function ($scope, $stateParams, todoTaskService) {
    $scope.tasks = todoTaskService.find($stateParams.id);
    $scope.selectedListId = $stateParams.id;

    $scope.makeActiveTask = function(id) {
        angular.forEach($scope.tasks, function (u, i) {
            if (u.Id === id) {
                $scope.tasks[i].TaskStateRefId = 1;
            }
        });
    };

    $scope.makeCompletedTask = function (id) {
        angular.forEach($scope.tasks, function (u, i) {
            if (u.Id === id) {
                $scope.tasks[i].TaskStateRefId = 2;
            }
        });
    };

    $scope.addNewTodoTask = function (listId) {
        debugger;
        if ($scope.newTodoTaskName != "") {
            var id = $scope.tasks[$scope.tasks.length - 1].Id + 1;
            $scope.tasks.push({ TodoTaskName: $scope.newTodoTaskName, TaskStateRefId: 1, Id: id });
            $scope.newTodoTaskName = "";
        }
    };
}]);

app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');
    debugger;
    $stateProvider
        .state('todoTasks', {
            url: 'todolists/:id/todotasks',
            templateUrl: '/Partials/TodoTasks',
            controller: 'todoTaskController'
        });
    //.state('edit',{
    //    url: '/edit',
    //    views: {
    //        'editModal': {
    //            templateUrl: '/Partials/EditTodoListModal',
    //            controller: 'wunderlistAppController'
    //        }
    //    }
    //});
}]);