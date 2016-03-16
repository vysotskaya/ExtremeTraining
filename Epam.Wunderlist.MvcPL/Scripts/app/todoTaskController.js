angular.module('wunderlistApp')
    .controller('todoTaskController', function ($scope, $stateParams, $filter, todoTaskService, $state) {
        $scope.activeTasks = [];
        $scope.completedTasks = [];

        $scope.gotodetail = function (taskId) {
            $state.go('todoTasks.detailsTask', { idTask: taskId });
        }

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

        //$scope.$watch('activeTasks', function (newModel, oldModel) {
        //    if (newModel.length < oldModel.length) {
        //        angular.forEach($scope.activeTasks, function (u, i) {
        //            $scope.activeTasks[i].Priority = i;
        //        });
        //        todoTaskService.updatePriorityTodotasks($scope.activeTasks);
        //    }
        //}, true);

        $scope.endDragTask = function () {
            debugger;
            angular.forEach($scope.activeTasks, function (u, i) {
                $scope.activeTasks[i].Priority = i;
            });
            todoTaskService.updatePriorityTodotasks($scope.activeTasks);
        }

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

        $scope.updateTodoTaskName = function (state, id, name) { //Katy
            $scope.selectedTask.TodoTaskName = name;
            if (state == 1) {
                angular.forEach($scope.activeTasks, function (t, i) {
                    if (t.Id === id) {
                        $scope.$parent.activeTasks[i].TodoTaskName = name;
                        todoTaskService.updateTodotask($scope.$parent.activeTasks[i]);
                    }
                });
            } else {
                angular.forEach($scope.completedTasks, function (t, i) {
                    if (t.Id === id) {
                        $scope.$parent.completedTasks[i].TodoTaskName = name;
                        todoTaskService.updateTodotask($scope.$parent.completedTasks[i]);
                    }
                });
            }
        };

        $scope.updateTodoTaskNote = function (id, note) {
            if ($scope.selectedTask.TodoTaskNote == "") {
                $scope.selectedTask.TodoTaskNote = "Добавить заметку...";
                return;
            }
            $scope.selectedTask.TodoTaskNote = note;
            todoTaskService.updateTodotask($scope.selectedTask);

        };

        todoTaskService.getTodotaskById($stateParams.idTask, function (response) {
            debugger;
            $scope.selectedTask = response;
            if ($scope.selectedTask.DueDate == null) {
                $scope.selectedTask.DueDate = "Задать дату выполнения";
            }
            if ($scope.selectedTask.TodoTaskNote == null || $scope.selectedTask.TodoTaskNote == "") {
                $scope.selectedTask.TodoTaskNote = "Добавить заметку...";
            }
        });

        $scope.makeActiveNoteArea = function() {
            if ($scope.selectedTask.TodoTaskNote == "Добавить заметку...") {
                $scope.selectedTask.TodoTaskNote = "";
            }
        }

        $scope.updateTodoTaskState = function (selectedTask) {
            if (selectedTask.TaskStateRefId == 1) {
                selectedTask.TaskStateRefId = 2;
                angular.forEach($scope.completedTasks, function (t, i) {
                    if (t.Id === selectedTask.id) {
                        $scope.completedTasks[i].TaskStateRefId = 2;
                    }
                });
            }
            else {
                selectedTask.TaskStateRefId = 1;
                angular.forEach($scope.activeTasks, function (t, i) {
                    if (t.Id === selectedTask.id) {
                        $scope.activeTasks[i].TaskStateRefId = 1;
                    }
                });
            }
            
            todoTaskService.updateTodotask(selectedTask);
        };

        $scope.deleteTodoTask = function (state, taskId) {
            if (state == 1) {
                angular.forEach($scope.activeTasks, function (s, i) {
                    if (s.Id === taskId) {
                        $scope.activeTasks.splice(i, 1);
                    }
                });
            } else {
                angular.forEach($scope.completedTasks, function (s, i) {
                    if (s.Id === taskId) {
                        $scope.completedTasks.splice(i, 1);
                    }
                });
            }
            todoTaskService.deleteTodotask(taskId);
        };

        $scope.updateTaskDueDate = function (id, duedate) {
            $scope.selectedTask.DueDate = $("input[id=datepicker]").val();
            todoTaskService.updateTodotask($scope.selectedTask);
        }
    });