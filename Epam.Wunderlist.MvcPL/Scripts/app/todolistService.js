angular.module('wunderlistApp').factory('todoListService', function ($resource) {
    return {
        getTodolists: function () {
            var resource = $resource('http://localhost:53028/api/todolist', {},
			{
			    get: { method: 'GET', isArray: true }
			});
            return resource.get.apply(this, arguments);
        },

        addTodolist: function () {
            var resource = $resource('http://localhost:53028/api/todoList', {},
			{
				save: {
				    method:'POST',
				    transformResponse: function (data) {
				        return { data: data};
				    }
				}
			});
			return resource.save.apply(this, arguments);
        },

        deleteTodolist: function (todoListId) {
            var resource = $resource('http://localhost:53028/api/todolist/' + todoListId, {},
			{
				remove: {method:'DELETE'}
			});
			return resource.remove.apply(this, arguments);
        },

        updateTodoList: function (todoList) {
            var resource = $resource('http://localhost:53028/api/todolist/' + todoList.Id, {},
			{
			    update: { method: 'PUT' }
			});
            return resource.update.apply(this, arguments);
        }
    }
});