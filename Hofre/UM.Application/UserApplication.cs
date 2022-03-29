using Exceptions;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UM.Application.Contract.User;
using UM.Domain.UserAgg;

namespace UM.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IPasswordHasher _Hash;
        private readonly IUserRepository _repository;
        private readonly IFileUploader _uploader;

        public UserApplication(IUserRepository repository, IPasswordHasher Hash, IFileUploader uploader)
        {
            _repository = repository;
            _Hash = Hash;
            _uploader = uploader;
        }

        public async Task Active(long Id)
        {
            var user = await _repository.GetBy(Id);
            user.Active();
            await _repository.Save();
        }

        public async Task ChangePassword(long Id, string newPassword)
        {
            var user = await _repository.GetBy(Id);
            if (user == null)
                throw new NotFoundException(nameof(user), user.Id);
            var Password = await _Hash.Hash(newPassword);
            user.ChangePassword(Password);
            await _repository.Save();



        }

        public async Task Create(CreateUser commend)
        {
            string profilePhoto = _uploader.SingleUploader(commend.ProfilePicture, "ProfilePhotos", commend.Username);
            var user = new UserModel(commend.Username, commend.Email, commend.Phone, commend.Password,profilePhoto, commend.RoleId);
            await _repository.Create(user);
        }

        public async Task DeActive(long Id)
        {
            var user = await _repository.GetBy(Id);
            user.DeActive();
            await _repository.Save();
        }

        public async Task Edit(EditUser commend)
        {
            string profilePhoto = _uploader.SingleUploader(commend.ProfilePicture, "ProfilePhotos", commend.Username);
            var user = await _repository.GetBy(commend.Id);
            user.Edit(commend.Username, commend.Email, commend.Phone, commend.Password, profilePhoto, commend.RoleId);
            await _repository.Save();
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<EditUser> GetValueForEdit(long Id)
        {
            var user = await _repository.GetBy(Id);
            return new EditUser
            {
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                RoleId = user.RoleId
            };
        }

        public async Task Remove(long Id)
        {
            await _repository.Remove(Id);
            await _repository.Save();

        }
    }
}
