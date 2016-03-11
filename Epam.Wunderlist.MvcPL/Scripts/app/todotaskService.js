angular.module('wunderlistApp').factory('todoTaskService', function ($resource) {

    return {
        getTodotasksByListId: function (todoListId) {
            var resource = $resource('http://localhost:53028/api/todolists/' + todoListId + "/todotask", {},
			{
			    get: {
			        method: 'GET',
			        isArray: true
			    }
			});
            return resource.get.apply(this, arguments);
        },

        getTodotaskById: function (todoTaskId) {
            var resource = $resource('http://localhost:53028/api/todotask/' + todoTaskId, {},
			{
			    get: { method: 'GET', isArray: false }
			});
            return resource.get.apply(this, arguments);
        },

        addTodotask: function () {
            var resource = $resource('http://localhost:53028/api/todotask/', {},
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

        deleteTodotask: function (todoTaskId) {
            var resource = $resource('http://localhost:53028/api/todotask/' + todoTaskId, {},
			{
			    remove: { method: 'DELETE' }
			});
            return resource.remove.apply(this, arguments);
        },

        updateTodotask: function (todoTask) {
            debugger;
            var resource = $resource('http://localhost:53028/api/todotask/' + todoTask.Id, {},
			{
			    update: { method: 'PUT' }
			});
            return resource.update.apply(this, arguments);
        }
    }
});