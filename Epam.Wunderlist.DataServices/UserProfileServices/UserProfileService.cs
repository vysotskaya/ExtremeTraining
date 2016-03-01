﻿using System.Collections.Generic;
using System.Linq;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;

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
            return _userProfileRepository.GetAll().ToList();
        }

        public UserProfile GetById(int id)
        {
            return _userProfileRepository.GetById(id);
        }

        public void Create(UserProfile entity)
        {
            _userProfileRepository.Create(entity);
            _unitOfWork.Commit();
        }

        public void Update(UserProfile entity)
        {
            _userProfileRepository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(UserProfile entity)
        {
            _userProfileRepository.Delete(entity);
            _unitOfWork.Commit();
        }
    }
}
