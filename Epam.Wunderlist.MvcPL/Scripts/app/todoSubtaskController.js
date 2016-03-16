angular.module('wunderlistApp')
    .controller('todoSubtaskController', function ($scope, $stateParams, todoSubtaskService) {
        todoSubtaskService.getTodoSubtasksByTaskId($stateParams.idTask, function (response) {
            $scope.subtasks = response;
        });
        $scope.selectedTaskId = $stateParams.idTask;

        $scope.addSubtask = function () {
            if ($scope.subtaskName == "") {
                return;
            }
            var todoSubtask = {
                TodoSubtaskName: $scope.subtaskName,
                TaskStateRefId: 1,
                TodoTaskRefId: $scope.selectedTaskId
            };
            todoSubtaskService.addTodoSubtask(todoSubtask, function (data) {
                $scope.subtasks.push(JSON.parse(data.data));
                $scope.subtaskName = "";
            });

        };
    
        $scope.updateSubtaskName = function (subtask, name) {
            if ($scope.subtaskChangeName == "") {
                return;
            }
            subtask.TodoSbtaskName =$scope.subtaskNameChange;
            todoSubtaskService.updateTodoSubtask(subtask);
        };

        $scope.deleteSubtask = function (subtaskId) {
            angular.forEach($scope.subtasks, function (s, i) {
                if(s.Id === subtaskId )
                {
                    $scope.subtasks.splice(i, 1);
                }

            });
            todoSubtaskService.deleteTodoSubtask(subtaskId);
        
        };

        $scope.updateSubtaskState = function (subtask) {
        
            if (subtask.TaskStateRefId == 1) {
                subtask.TaskStateRefId = 2;
            }
            else
                subtask.TaskStateRefId = 1;
            todoSubtaskService.updateTodoSubtask(subtask);
        
        };

    });