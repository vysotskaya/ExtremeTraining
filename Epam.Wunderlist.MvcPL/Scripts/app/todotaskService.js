angular.module('wunderlistApp')
    .factory('todoTaskService', function ($resource, WUNDERLIST_CONSTANTS) {
        function getTodotasksByListId(todoListId) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todolists/' + todoListId + "/todotask", {},
            {
                get: {
                    method: 'GET',
                    isArray: true
                }
            });
            return resource.get.apply(this, arguments);
        }

        function getTodotaskById(todoTaskId) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todotask/' + todoTaskId, {},
            {
                get: { method: 'GET', isArray: false }
            });
            return resource.get.apply(this, arguments);
        }

        function addTodotask() {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todotask/', {},
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

        function deleteTodotask(todoTaskId) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todotask/' + todoTaskId, {},
            {
                remove: { method: 'DELETE' }
            });
            return resource.remove.apply(this, arguments);
        }

        function updateTodotask(todoTask) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todotask/' + todoTask.Id, {},
            {
                update: { method: 'PUT' }
            });
            return resource.update.apply(this, arguments);
        }

        function updatePriorityTodotasks() {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todotask/', {},
            {
                update: { method: 'PUT' }
            });
            return resource.update.apply(this, arguments);
        }
        
        return {
            getTodotasksByListId: getTodotasksByListId,
            getTodotaskById: getTodotaskById,
            addTodotask: addTodotask,
            deleteTodotask: deleteTodotask,
            updateTodotask: updateTodotask,
            updatePriorityTodotasks: updatePriorityTodotasks
        }
    });