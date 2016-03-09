angular.module('wunderlistApp').factory('todoListService', function ($resource) {
    return {
        getTodolists: function () {
            var resource = $resource('http://localhost:53028/api/TodoList/Get', {},
			{
			    get: { method: 'GET', isArray: true }
			});

            return resource.get.apply(this, arguments);
        },
        addTodolist: function () {
            var resource = $resource('http://localhost:53028/api/TodoList/Post', {},
			{
				save: {method:'POST'}
			});
			return resource.save.apply(this, arguments);
		},
        deleteTodolist: function (todoListId) {
            debugger;
            var resource = $resource('http://localhost:53028/api/TodoList/Delete/' + todoListId, {},
			{
				remove: {method:'DELETE'}
			});

			return resource.remove.apply(this, arguments);
		},
        updateTodoList: function (todoList) {
            var resource = $resource('http://localhost:53028/api/TodoList/Put/' + todoList.Id, {},
			{
			    update: { method: 'PUT' }
			});

            return resource.update.apply(this, arguments);
        }

    }
});