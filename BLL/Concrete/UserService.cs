using System.Collections.Generic;
using System.Linq;
using BLL.Interface.BllEntities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repositories;

namespace BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return _userRepository.GetAll().Select(u => u.ToUserEntity());
        }

        public UserEntity GetUserEntity(int id)
        {
            return _userRepository.GetById(id).ToUserEntity();
        }

        public void CreateUser(UserEntity user)
        {
            _userRepository.Create(user.ToDalUser());
            _unitOfWork.Commit();
        }

        public void UpdateUser(UserEntity user)
        {
            _userRepository.Update(user.ToDalUser());
            _unitOfWork.Commit();
        }

        public void DeleteUser(UserEntity user)
        {
            _userRepository.Delete(user.ToDalUser());
            _unitOfWork.Commit();
        }

        public UserEntity GetUserByEmail(string email)
        {
            //todo GetByPredicate

            return _userRepository.GetAll()
                .FirstOrDefault(u => u.Email == email).ToUserEntity(); 
        }
    }
}
