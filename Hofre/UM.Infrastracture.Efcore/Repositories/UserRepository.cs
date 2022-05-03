using Exceptions;
using Frameworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Application.Contract.User;
using UM.Domain.UserAgg;

namespace UM.Infrastracture.Efcore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        private readonly IPasswordHasher _hash;
        public UserRepository(UserContext context, IPasswordHasher hash)
        {
            _context = context;
            _hash = hash;
        }

        public async Task<bool> CheckIdentity(string username, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.Username == username);
            // if (user == null) throw new NotFoundException(nameof(user), user.Username);

            if (user != null && ( _hash.Check(user.Password, password)).Verified) return true;
            else return false;
           

        }

        public async Task<bool> CheckIdentity(string username, string email, string phoneNumber)
        {
            return await _context.users.AnyAsync(x => x.Username == username || x.Email == email || x.Phone == phoneNumber);
        }

        public async Task Create(UserModel commend)
        {
           await _context.users.AddAsync(commend);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }

        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var users = await _context.users.Select(x => new UserViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Email = x.Email,
                IsActive = x.IsActive,
                Phone = x.Phone,
                ProfilePicture = x.ProfilePicture,
                RoleId = x.RoleId,
                Username = x.Username,
            }).ToListAsync();

            users.ForEach(x =>x.RoleName = _context.userRoles
            .FirstOrDefault(q => q.Id == x.RoleId).RoleName);

            return users == null ? throw new NotFoundException(nameof(users)) : users;
        }

        public async Task<UserModel> GetBy(long Id)
        {

            var user = await _context.users.FirstOrDefaultAsync(x => x.Id == Id);

            if (user == null)
                throw new NotFoundException(nameof(user), Id);
            return user;

        }

        public async Task<UserModel> GetBy(string Username)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.Username == Username);

            if (user == null)
                throw new NotFoundException(nameof(user), Username);
            return user;
        }

        public async Task Remove(long Id)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.Id == Id);

            if (user == null)
                throw new NotFoundException(nameof(user), Id);

            _context.users.Remove(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }
    }
}
