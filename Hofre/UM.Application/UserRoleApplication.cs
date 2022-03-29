using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UM.Application.Contract.UserRole;
using UM.Domain.UserRoleAgg;

namespace UM.Application
{
    public class UserRoleApplication : IUserRoleApplication
    {
        private readonly IUserRoleRepository _repository;

        public UserRoleApplication(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateUserRole commend)
        {
            var userRole = new UserRoleModel(commend.RoleName);
            await _repository.Create(userRole);

        }
     
        public async Task<List<UserRoleViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Remove(long Id)
        {
            await _repository.Remove(Id);
        }
    }
}
