angular.module('wunderlistApp')
    .factory('todoSubtaskService', function ($resource, WUNDERLIST_CONSTANTS) {
        function updateTodoSubtask(todoSubtask) {
            debugger;
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todosubtask/' + todoSubtask.Id, {},
            {
                update: { method: 'PUT' }
            });
            return resource.update.apply(this, arguments);
        }

        function getTodoSubtasksByTaskId(todoTaskId) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todotask/' + todoTaskId + "/todosubtask", {},
            {
                get: {
                    method: 'GET',
                    isArray: true
                }
            });
            return resource.get.apply(this, arguments);
        }

        function getTodoSubtaskById(todoSubtaskId) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todosubtask/' + todoSubtaskId, {},
            {
                get: { method: 'GET', isArray: false }
            });
            return resource.get.apply(this, arguments);
        }

        function addTodoSubtask() {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todosubtask/', {},
            {
                save: {
                    method: 'POST',
                    transformResponse: function (data) {
                        return { data: data };
                    }
                }
            });
            return resource.save.apply(this, arguments);
        }

        function deleteTodoSubtask(todoSubtaskId) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todosubtask/' + todoSubtaskId, {},
            {
                remove: { method: 'DELETE' }
            });
            return resource.remove.apply(this, arguments);
        }

        return {
            getTodoSubtasksByTaskId: getTodoSubtasksByTaskId,
            getTodoSubtaskById: getTodoSubtaskById,
            addTodoSubtask: addTodoSubtask,
            deleteTodoSubtask: deleteTodoSubtask,
            updateTodoSubtask: updateTodoSubtask
        }
    });