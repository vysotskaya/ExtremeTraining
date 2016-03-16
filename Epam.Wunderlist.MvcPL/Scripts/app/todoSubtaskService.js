angular.module('wunderlistApp').factory('todoSubtaskService', function ($resource) {

    return {
        getTodoSubtasksByTaskId: function (todoTaskId) {
            var resource = $resource('http://localhost:53028/api/todotask/' + todoTaskId + "/todosubtask", {},
			{
			    get: {
			        method: 'GET',
			        isArray: true
			    }
			});
            return resource.get.apply(this, arguments);
        },

        getTodoSubtaskById: function (todoSubtaskId) {
            var resource = $resource('http://localhost:53028/api/todosubtask/' + todoSubtaskId, {},
			{
			    get: { method: 'GET', isArray: false }
			});
            return resource.get.apply(this, arguments);
        },

        addTodoSubtask: function () {
            var resource = $resource('http://localhost:53028/api/todosubtask/', {},
			{
			    save: {
			        method: 'POST',
			        transformResponse: function (data) {
			            return { data: data };
			        }
			    }
			});
            return resource.save.apply(this, arguments);
        },

        deleteTodoSubtask: function (todoSubtaskId) {
            var resource = $resource('http://localhost:53028/api/todosubtask/' + todoSubtaskId, {},
			{
			    remove: { method: 'DELETE' }
			});
            return resource.remove.apply(this, arguments);
        },

        updateTodoSubtask: function (todoSubtask) {
            debugger;
            var resource = $resource('http://localhost:53028/api/todosubtask/' + todoSubtask.Id, {},
			{
			    update: { method: 'PUT' }
			});
            return resource.update.apply(this, arguments);
        }
    }

});