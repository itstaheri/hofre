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

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task Create(UserModel commend)
        {
            _context.users.Add(commend);
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
