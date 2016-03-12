var app = angular.module('wunderlistApp', ['ngResource', 'ui.router']);

app.controller('wunderlistAppController',['todoListService', '$scope', function (todoListService, $scope) {

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
        $scope.todoList.UserProfileRefId = userId;
        todoListService.addTodolist($scope.todoList, function(data) {
            $scope.lists.push(
            {
                TodoListName: $scope.todoList.TodoListName,
                Id: data.data,
                UserProfileRefId: $scope.todoList.UserProfileRefId
            });
             $scope.todoList.TodoListName = "";
        });
    };

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
        todoListService.updateTodoList($scope.editedTodoList);
        $scope.selectedTodoListName = $scope.editedTodoList.TodoListName;
    }

    $scope.deleteTodoList = function (listId) {
        angular.forEach($scope.lists, function (u, i) {
            if (u.Id === listId) {
                $scope.lists.splice(i, 1);
            }
        });
        todoListService.deleteTodolist(listId);
        $scope.selectedTodoListName = "";
    }
}]);

app.controller('todoTaskController', ['$scope', '$stateParams', 'todoTaskService', function ($scope, $stateParams, todoTaskService) {
    todoTaskService.getTodotasksByListId($stateParams.id, function (response) {
        $scope.tasks = response;
    });

    //$scope.tasks = todoTaskService.find($stateParams.id);
    $scope.selectedListId = $stateParams.id;

    $scope.updateStateTodoTask = function (id, state) {
        angular.forEach($scope.tasks, function (u, i) {
            if (u.Id === id) {
                $scope.tasks[i].TaskStateRefId = state;
                todoTaskService.updateTodotask($scope.tasks[i]);
            }
        });
    };
 
    $scope.addNewTodoTask = function (listId) {
        if ($scope.newTodoTaskName == "") {
            return;
        }
        var todoTask = {
            TodoTaskName: $scope.newTodoTaskName,
            DateAdded: new Date(),
            TaskStateRefId: 1,
            TodoListRefId: listId
        };
        todoTaskService.addTodotask(todoTask, function (data) {
            $scope.tasks.push(JSON.parse(data.data));
            $scope.newTodoTaskName = "";
        });
    };
}]);

app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');
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