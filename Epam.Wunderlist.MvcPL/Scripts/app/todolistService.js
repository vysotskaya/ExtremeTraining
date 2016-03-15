angular.module('wunderlistApp')
    .factory('todoListService', function ($resource, WUNDERLIST_CONSTANTS) {
        function getTodolists() {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todolist', {},
            {
                get: { method: 'GET', isArray: true }
            });
            return resource.get.apply(this, arguments);
        }

        function addTodolist() {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL +'/api/todoList', {},
            {
                save: {
                    method:'POST',
                    transformResponse: function (data) {
                        return { data: data};
                    }
                }
            });
            return resource.save.apply(this, arguments);
        }

        function deleteTodolist(todoListId) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todolist/' + todoListId, {},
            {
                remove: {method:'DELETE'}
            });
            return resource.remove.apply(this, arguments);
        }

        function updateTodoList(todoList) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/todolist/' + todoList.Id, {},
            {
                update: { method: 'PUT' }
            });
            return resource.update.apply(this, arguments);
        }

        return {
            getTodolists: getTodolists,
            addTodolist: addTodolist,
            deleteTodolist: deleteTodolist,
            updateTodoList: updateTodoList
        }
    });