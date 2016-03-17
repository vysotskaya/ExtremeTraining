angular.module('wunderlistApp')
    .controller('wunderlistAppController', function($state, todoListService, todoTaskService, userProfileService, $scope) {

        $scope.$on('handleUserProfileChange', function() {
            var userProfile = userProfileService.getUserProfileData();
            $scope.imageSrc = userProfile.Avatar;
            $scope.userName = userProfile.UserName;
        });

        $scope.getListsAndUserProfileData = function() {
            todoListService.getTodolists(function(response) {
                $scope.lists = response;
                angular.forEach($scope.lists, function(u, i) {
                    $scope.lists[i].draggedTasks = [];
                });
                userProfileService.getUserProfile(function(response) {
                    userProfileService.setUserProfileData(response);
                    var userProfile = userProfileService.getUserProfileData();
                    $scope.imageSrc = userProfile.Avatar;
                    $scope.userName = userProfile.UserName;
                });
                if ($scope.lists.length != 0) {
                    $state.go('todoTasks', { id: $scope.lists[0].Id });
                    $scope.selectedTodoListName = $scope.lists[0].TodoListName;
                }
            });
        };

        $scope.getListsAndUserProfileData();

        $scope.insertDraggedTask = function() {
            for (var f = 0; f < $scope.lists.length; f++) {
                if ($scope.lists[f].draggedTasks.length != 0) {
                    var draggedTask = $scope.lists[f].draggedTasks[0];
                    draggedTask.Priority = -1;
                    draggedTask.TodoListRefId = $scope.lists[f].Id;
                    todoTaskService.updateTodotask(draggedTask);
                    $scope.lists[f].draggedTasks = [];
                }
            }
        };

        $scope.selectTodoList = function (listId, listName) {
            $scope.selectedTodoListName = listName;
        }

        $scope.todoList = {};


        $scope.addNewTodoList = function(userId) {
            if ($scope.todoList.TodoListName == "") {
                return;
            }
            $scope.todoList.UserProfileRefId = userId;
            todoListService.addTodolist($scope.todoList, function(data) {
                $scope.lists.push(
                {
                    TodoListName: $scope.todoList.TodoListName,
                    Id: data.data,
                    UserProfileRefId: $scope.todoList.UserProfileRefId,
                });
                $scope.lists[$scope.lists.length - 1].draggedTasks = [];
                $scope.todoList.TodoListName = "";
            });
        };

        $scope.editedTodoList = {};

        $scope.prepareForEdit = function(listId) {
            angular.forEach($scope.lists, function(u, i) {
                if (u.Id === listId) {
                    $scope.editedTodoList.TodoListName = $scope.lists[i].TodoListName;
                    $scope.editedTodoList.Id = listId;
                    $scope.editedTodoList.UserProfileRefId = $scope.lists[i].UserProfileRefId;
                }
            });
        };

        $scope.editTodoList = function() {
            if ($scope.editedTodoList.TodoListName == "") {
                return;
            }
            angular.forEach($scope.lists, function(u, i) {
                if (u.Id === $scope.editedTodoList.Id) {
                    $scope.lists[i].TodoListName = $scope.editedTodoList.TodoListName;
                }
            });
            todoListService.updateTodoList($scope.editedTodoList);
            $scope.selectedTodoListName = $scope.editedTodoList.TodoListName;
        }

        $scope.deleteTodoList = function(listId) {
            angular.forEach($scope.lists, function(u, i) {
                if (u.Id === listId) {
                    $scope.lists.splice(i, 1);
                }
            });
            todoListService.deleteTodolist(listId);
            if ($scope.lists.length != 0) {
                $state.go('todoTasks', { id: $scope.lists[0].Id });
                $scope.selectedTodoListName = $scope.lists[0].TodoListName;
            } else {
                $scope.selectedTodoListName = "";
            }
        }
    });