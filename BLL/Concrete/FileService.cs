using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Services;
using BLL.Interface.BllEntities;
using DAL.Interface.Repositories;
using BLL.Mappers;

namespace BLL.Concrete
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _uow;
        private readonly IFileRepository _fileRepository;

        public FileService(IUnitOfWork uow, IFileRepository fileRepository)
        {
            _uow = uow;
            _fileRepository = fileRepository;
        }

        public void Create(FileEntity entity)
        {
            _fileRepository.Create(entity.ToDalFile());
            _uow.Commit();
        }

        public void Delete(FileEntity entity)
        {
            _fileRepository.Delete(entity.ToDalFile());
            _uow.Commit();
        }

        public IEnumerable<FileEntity> GetAll()
        {
            return _fileRepository.GetAll().Select(file => file.ToBllFile());
        }

        public FileEntity GetById(int key)
        {
            return _fileRepository.GetById(key).ToBllFile();
        }

        public void Update(FileEntity entity)
        {
            _fileRepository.Update(entity.ToDalFile());
            _uow.Commit();
        }

        public IEnumerable<FileEntity> GetByTaskId(int taskId)
        {
            return _fileRepository.GetByTaskId(taskId).Select(file => file.ToBllFile());
        }
    }
}
