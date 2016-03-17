using System;
using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.Logger;

namespace Epam.Wunderlist.DataServices.UserProfileServices
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserProfile> GetAll()
        {
            try
            {
                return _userProfileRepository.GetAll().ToList();
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return new List<UserProfile>();
            }
        }

        public UserProfile GetById(int id)
        {
            try
            {
                return _userProfileRepository.GetById(id);
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return null;
            }
        }

        public UserProfile GetByEmail(string email)
        {
            try
            {
                return _userProfileRepository.GetUserProfileByEmail(email);
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return null;
            }
        }

        public int Create(UserProfile entity)
        {
            try
            {
                var result = _userProfileRepository.Create(entity);
                _unitOfWork.Commit();
                return result;
            }
            catch (Exception e)
            {
                Log.LogError(e);
                return 0;
            }
        }

        public void Update(UserProfile entity)
        {
            try
            {
                _userProfileRepository.Update(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }

        public void Delete(UserProfile entity)
        {
            try
            {
                _userProfileRepository.Delete(entity);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Log.LogError(e);
            }
        }
    }
}
