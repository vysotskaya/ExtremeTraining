angular.module('wunderlistApp', ['ngResource', 'ui.router', 'dndLists'])
    .config([
        '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('todoTasks', {
                    url: 'todolists/:id/todotasks',
                    templateUrl: '/Partials/TodoTasks',
                    controller: 'todoTaskController'
                });
        }
    ])
    .constant('WUNDERLIST_CONSTANTS', {
        'URL': 'http://localhost:53028'
    })
    .controller('editUserProfileController', function($scope, $rootScope, fileReader, userProfileService) {

        $scope.userProfile = {};

        $rootScope.setUserProfileData = function() {
            debugger;
            var userProfile = userProfileService.getUserProfileData();
            $scope.imageSrc = userProfile.Avatar;
            $scope.userProfile.UserName = userProfile.UserName;
            $scope.userProfile.Email = userProfile.Email;
        }

        $scope.getFile = function() {
            fileReader.readAsDataUrl($scope.file, $scope)
                .then(function(result) {
                    $scope.imageSrc = result;
                });
        };

        $scope.updateUserProfile = function() {
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
    })
    .directive("ngFileSelect", function() {
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
    })
    .controller('userProfileController', function($scope, $rootScope) {
        $scope.prepareUserProfileModalForEdit = function() {
            $rootScope.setUserProfileData();
        }
    })
    .controller('wunderlistAppController', function(todoListService, userProfileService, $scope) {

        $scope.$on('handleUserProfileChange', function() {
            debugger;
            var userProfile = userProfileService.getUserProfileData();
            $scope.imageSrc = userProfile.Avatar;
            $scope.userName = userProfile.UserName;
        });

        $scope.getListsAndUserProfileData = function() {
            todoListService.getTodolists(function(response) {
                $scope.lists = response;
                userProfileService.getUserProfile(function(response) {
                    userProfileService.setUserProfileData(response);
                    var userProfile = userProfileService.getUserProfileData();
                    $scope.imageSrc = userProfile.Avatar;
                    $scope.userName = userProfile.UserName;
                });
            });
        };

        $scope.getListsAndUserProfileData();

        $scope.selectTodoList = function(listId, listName) {
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
                    UserProfileRefId: $scope.todoList.UserProfileRefId
                });
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
            $scope.selectedTodoListName = "";
        }
    });

angular.module('wunderlistApp')
    .controller('todoTaskController', function ($scope, $stateParams, $filter, todoTaskService) {
        $scope.activeTasks = [];
        $scope.completedTasks = [];

        todoTaskService.getTodotasksByListId($stateParams.id, function (response) {
            angular.forEach(response, function(task, i) {
                if (task.TaskStateRefId == 1) {
                    $scope.activeTasks.push(task);
                } else {
                    $scope.completedTasks.push(task);
                }
            });
            var orderBy = $filter('orderBy');
            $scope.activeTasks = orderBy($scope.activeTasks, 'Priority', false);
            $scope.completedTasks = orderBy($scope.completedTasks, 'Priority', false);
        });    

        //for drag and drop
        $scope.models = {
            selected: null
        };

        $scope.$watch('activeTasks', function (newModel, oldModel) {
            if (newModel.length < oldModel.length) {
                angular.forEach($scope.activeTasks, function (u, i) {
                    $scope.activeTasks[i].Priority = i;
                });
                todoTaskService.updatePriorityTodotasks($scope.activeTasks);
            }
        }, true);

        $scope.dragoverCallback = function (event, index, external, type) {
            //console.log(event, index, external, type);
            return index < 10;
        };

        $scope.dropCallback = function (event, index, item, external, type, allowedType) {
            console.log(event, index, item, external, type, allowedType);
            if (external) {
                if (allowedType === 'itemType' && !item.label) return false;
                if (allowedType === 'containerType' && !angular.isArray(item)) return false;
            }
            return item;
        };

        $scope.selectedListId = $stateParams.id;

        $scope.makeActiveTodoTask = function(id) {
            angular.forEach($scope.completedTasks, function (u, i) {
                if (u.Id === id) {
                    var updateTask = u;
                    updateTask.TaskStateRefId = 1;
                    $scope.completedTasks.splice(i, 1);
                    updateTask.Priority = $scope.activeTasks.length;
                    $scope.activeTasks.push(updateTask);
                    todoTaskService.updateTodotask(updateTask);
                }
            });
        }

        $scope.makeCompletedTodoTask = function (id) {
            debugger;
            angular.forEach($scope.activeTasks, function (u, i) {
                if (u.Id === id) {
                    var updateTask = u;
                    updateTask.TaskStateRefId = 2;
                    $scope.activeTasks.splice(i, 1);
                    $scope.completedTasks.push(updateTask);
                    todoTaskService.updateTodotask(updateTask);
                }
            });
        }
 
        $scope.addNewTodoTask = function (listId) {
            if ($scope.newTodoTaskName == "") {
                return;
            }
            var todoTask = {
                TodoTaskName: $scope.newTodoTaskName,
                DateAdded: new Date(),
                TaskStateRefId: 1,
                TodoListRefId: listId,
                Priority: $scope.activeTasks.length
            };
            todoTaskService.addTodotask(todoTask, function (data) {
                $scope.activeTasks.push(JSON.parse(data.data));
                $scope.newTodoTaskName = "";
            });
        };
    });