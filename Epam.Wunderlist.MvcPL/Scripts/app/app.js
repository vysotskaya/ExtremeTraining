var app = angular.module('wunderlistApp', ['ngResource', 'ui.router']);

app.controller('editUserProfileController', ['$scope', '$rootScope', 'fileReader', 'userProfileService',
        function ($scope, $rootScope, fileReader, userProfileService) {

    $scope.userProfile = {};

    $rootScope.setUserProfileData = function () {
        debugger;
        var userProfile = userProfileService.getUserProfileData();
        $scope.imageSrc = userProfile.Avatar;
        $scope.userProfile.UserName = userProfile.UserName;
        $scope.userProfile.Email = userProfile.Email;
    }

    $scope.getFile = function () {
        fileReader.readAsDataUrl($scope.file, $scope)
            .then(function (result) {
                $scope.imageSrc = result;
            });
    };

    $scope.updateUserProfile = function () {
        debugger;
        if ($scope.userProfile.UserName == "") {
            return;
        }
        console.log($scope.userProfile);
        var userProfile = new FormData();
        userProfile.append('Avatar', $scope.userProfile.Avatar);
        userProfile.append('UserName', $scope.userProfile.UserName);
        userProfileService.updateUserProfile(userProfile);

        userProfileService.updateUserProfileDataOnView($scope.userProfile.UserName, 
            $scope.userProfile.Email, $scope.imageSrc);
        $rootScope.$broadcast('handleUserProfileChange');
    }
}]);

app.directive("ngFileSelect", function() {
    return {
        link: function($scope, el) {
            el.bind("change", function(e) {
                $scope.file = (e.srcElement || e.target).files[0];
                if ($scope.file.type.match('image.*')) {
                    $scope.userProfile.Avatar = $scope.file;
                    $scope.getFile();
                }
            });

        }
    };
});

app.controller('userProfileController', ['$scope', '$rootScope',
        function ($scope, $rootScope) {
            $scope.prepareUserProfileModalForEdit = function () {
                $rootScope.setUserProfileData();
            }
}]);

app.controller('wunderlistAppController', ['todoListService', 'userProfileService', '$scope',
    function (todoListService, userProfileService, $scope) {

    $scope.$on('handleUserProfileChange', function () {
        debugger;
        var userProfile = userProfileService.getUserProfileData();
        $scope.imageSrc = userProfile.Avatar;
        $scope.userName = userProfile.UserName;
    });

    $scope.getListsAndUserProfileData = function() {
        todoListService.getTodolists(function (response) {
            $scope.lists = response;
            userProfileService.getUserProfile(function (response) {
                debugger;
                userProfileService.setUserProfileData(response);
                var userProfile = userProfileService.getUserProfileData();
                $scope.imageSrc = userProfile.Avatar;
                $scope.userName = userProfile.UserName;
            });
        });
    };

    $scope.getListsAndUserProfileData();

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

    //for drag and drop

    $scope.models = {
        selected: null,
        lists: $scope.tasks
    };
    $scope.$watch('models', function(model) {
        $scope.modelAsJson = angular.toJson(model, true);
    }, true);

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
}]);