angular.module('wunderlistApp').factory('todoTaskService', function ($resource) {

    var tasksEven = [{ "TodoTaskName": "task1", "Id": "1", "TaskStateRefId" : "2" },
        { "TodoTaskName": "task2", "Id": "2", "TaskStateRefId": "1" },
        { "TodoTaskName": "task3", "Id": "3", "TaskStateRefId": "1" }];

    var tasks = [{ "TodoTaskName": "task4", "Id": "4", "TaskStateRefId": "1" },
        { "TodoTaskName": "task5", "Id": "5", "TaskStateRefId": "2" },
        { "TodoTaskName": "task6", "Id": "6", "TaskStateRefId": "1" }];

    return {
        find: function (id) {
            debugger;
            if (id & 1 == true) {
                return tasks;
            }
            //return _.find(shows, function (show) { return show.id == id });
            return tasksEven;
        }
    }
});