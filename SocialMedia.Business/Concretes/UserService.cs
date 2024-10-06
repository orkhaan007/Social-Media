﻿using System.Linq.Expressions;
using SocialMedia.Business.Abstrats;
using SocialMedia.DataAccess.Abstracts;
using SocialMedia.Entities.Models;

namespace SocialMedia.Business.Concretes
{
    public class UserService:IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal) { _userDal = userDal; }
      

        public async Task UpdateAsync(CustomIdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

             await _userDal.UpdateAsync(user);
        }

        public async Task DeleteAsync(CustomIdentityUser user)
        {
            if (user ==null)
            {
                throw new ArgumentException("Invalid user ID");
            }
             await _userDal.DeleteAsync(user);
        }

        public async Task<CustomIdentityUser> GetAsync(Expression<Func<CustomIdentityUser, bool>> filter)
        {
            return await _userDal.GetAsync(filter); 
        }

        public Task<List<CustomIdentityUser>> GetListAsync(Expression<Func<CustomIdentityUser, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteListAsync(List<CustomIdentityUser> entities)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(CustomIdentityUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "User cannot be null");
            }

             await _userDal.AddAsync(entity);
        }
    }
}
