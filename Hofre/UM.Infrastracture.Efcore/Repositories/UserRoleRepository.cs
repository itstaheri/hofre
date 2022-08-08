using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Application.Contract.UserRole;
using UM.Domain.UserRoleAgg;

namespace UM.Infrastracture.Efcore.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly UserContext _context;

        public UserRoleRepository(UserContext context)
        {
            _context = context;
        }

        public async Task AddPermissions(List<UserPermissionModel> commend)
        {
            await _context.userPermissions.AddRangeAsync(commend);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task Create(UserRoleModel commend)
        {
            _context.userRoles.Add(commend);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<UserRoleViewModel>> GetAll()
        {
            var userRoles = await _context.userRoles
                .Select(x => new UserRoleViewModel { Id = x.Id, RoleName = x.RoleName }).ToListAsync();
            return userRoles;
        }

        public async Task<UserRoleModel> GetBy(long Id)
        {
            return await _context.userRoles.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Remove(long Id)
        {
            var userRole = await _context.userRoles.FirstOrDefaultAsync(x => x.Id == Id);
            _context.userRoles.Remove(userRole);
            await _context.SaveChangesAsync();
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
