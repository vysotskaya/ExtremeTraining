﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.DataAccess.MSSqlDbModel;

namespace Epam.Wunderlist.DataAccess.MSSql.Concrete
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly DbContext _dbContext;
        private readonly ITodoSubtaskRepository _todoSubtaskRepository;

        public TodoTaskRepository(DbContext dbContext, ITodoSubtaskRepository todoSubtaskRepository)
        {
            _dbContext = dbContext;
            _todoSubtaskRepository = todoSubtaskRepository;
        }

        public IEnumerable<TodoTask> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoTask GetById(int key)
        {
            var todoTask = _dbContext.Set<TodoTaskDbModel>().FirstOrDefault(t => t.Id == key);
            return Mapper.DynamicMap<TodoTaskDbModel, TodoTask>(todoTask);
        }

        public TodoTask GetByPredicate(Expression<Func<TodoTask, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public int Create(TodoTask entity)
        {
            var todoTask = Mapper.Map<TodoTask, TodoTaskDbModel>(entity);
            _dbContext.Set<TodoTaskDbModel>().Add(todoTask);
            _dbContext.SaveChanges();
            return  todoTask.Id;
        }

        public void Update(TodoTask entity)
        {
            var existedTodoTask = _dbContext.Entry<TodoTaskDbModel>
                (
                    _dbContext.Set<TodoTaskDbModel>().Find(entity.Id)
                );
            if (existedTodoTask == null)
            {
                return;
            }
            existedTodoTask.State = EntityState.Modified;
            existedTodoTask.Entity.TodoTaskName = entity.TodoTaskName;
            existedTodoTask.Entity.TodoTaskNote = entity.TodoTaskNote;
            existedTodoTask.Entity.TaskStateRefId = entity.TaskStateRefId;
            existedTodoTask.Entity.DueDate = entity.DueDate;
            existedTodoTask.Entity.Priority = entity.Priority;
            existedTodoTask.Entity.TodoListRefId = entity.TodoListRefId;
        }

        public void Delete(TodoTask entity)
        {
            var subtasks = _todoSubtaskRepository.GetByTaskId(entity.Id);
            foreach (var subtask in subtasks)
            {
                var item = _todoSubtaskRepository.GetById(subtask.Id);
                _todoSubtaskRepository.Delete(item);
            }
            var todoTask = _dbContext.Set<TodoTaskDbModel>().Single(t => t.Id == entity.Id);
            _dbContext.Set<TodoTaskDbModel>().Remove(todoTask);
        }

        public ICollection<TodoTask> GetByTodoListId(int listId)
        {
            return _dbContext.Set<TodoTaskDbModel>()
                .Where(t => t.TodoListRefId == listId).ToList()
                .Select(t => Mapper.DynamicMap<TodoTaskDbModel, TodoTask>(t)).ToList();
        }
    }
}
