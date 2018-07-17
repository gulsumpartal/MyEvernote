using MyEvernote.BusinessLayer.Validation.User;
using MyEvernote.DataAccessLayer.EFRepositories;
using MyEvernote.DTO.Response;
using MyEvernote.DTO.Users;
using MyEvernote.Entities;
using System;

namespace MyEvernote.BusinessLayer.Users
{
    public class UserService
    {
        private Repository<EvernoteUser> repo;
        private readonly UserValidator _uservalidator;
        public UserService()
        {
            repo = new Repository<EvernoteUser>();
            _uservalidator = new UserValidator();
        }
        private EvernoteUser GetEvernoteUser(string userName, string password)
        {
            EvernoteUser result = repo.Find(p => p.IsActive == true && p.Username == userName.Trim() && p.Password == password.Trim());

            return result;
        }

        public ResponseMessage<UserDto> GetUserDetails(string username, string password)
        {
            var evernoteUser = GetEvernoteUser(username, password);

            var result = new ResponseMessage<UserDto>();
            result.IsSuccess = false;
            result.Result = null;

            if (evernoteUser != null)
            {
                if (evernoteUser.IsActive)
                {
                    UserDto data = new UserDto
                    {
                        UserId = evernoteUser.Id,
                        Name = evernoteUser.Name,
                        Surname = evernoteUser.Surname,
                        IsAdmin = evernoteUser.IsAdmin,
                        Email = evernoteUser.Email,
                        Username = evernoteUser.Username,
                        ProfileImagePath = evernoteUser.ImageFilePath
                    };
                    result.IsSuccess = true;
                    result.Result = data;
                }
                else
                {
                    result.Messages.Add("Kullanıcı bilgileri aktive edilmemiş lütfen mail adresinizi kontrol ediniz!");
                }
            }
            else
            {
                result.Messages.Add("Kullanıcı Adı veya Şifre Hatalı!");
            }
            return result;
        }

        public ResponseMessage<RegisterUserDto> AddUser(RegisterUserDto dto)
        {
            var result = new ResponseMessage<RegisterUserDto>();

            var mailIsValid = _uservalidator.MailIsValid(dto.Email);

            result = mailIsValid.IsSuccess ? _uservalidator.SameUserExists(dto) : mailIsValid;

            if (result.IsSuccess)
            {
                var userEntity = new EvernoteUser
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Password = dto.Password,
                    IsActive = false,
                    IsAdmin = false,
                    ActivateGuid = Guid.NewGuid()
                };

                int affectedRowCount = repo.Insert(userEntity);

                result.IsSuccess = affectedRowCount > 0 ? true : false;
            }
            return result;
        }

        public Guid GetActivedGuid(string username, string password)
        {
            return repo.Find(p => p.Username == username && p.Password == password).ActivateGuid;
        }

        public ResponseMessage<InsertUserDto> ValidateForActivedProfile(string activetedGuid)
        {
            return _uservalidator.ValidateForActivedUser(activetedGuid);
        }

        public ResponseMessage<InsertUserDto> ActivedUser(InsertUserDto dto)
        {
            ResponseMessage<InsertUserDto> result = new ResponseMessage<InsertUserDto>();
            try
            {
                var user = repo.Find(p => p.ActivateGuid.ToString() == dto.ActivedGuid);

                user.Name = dto.Name;
                user.Surname = dto.Surname;
                user.IsActive = true;
                user.ImageFilePath = dto.ImagePath;

                if (repo.Update(user) > 0)
                {
                    result.IsSuccess = true;
                    result.Messages.Add("İşlem Başarılı");
                }
                else
                {
                    result.IsSuccess = false;
                    result.Messages.Add("İşlem sırasında beklenmedik bir hata oluştu lütfen data sonra tekrar deneyin");
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages.Add("İşlem sırasında beklenmedik bir hata oluştu lütfen data sonra tekrar deneyin");
                Common.Helper.Utility.ReportError(ex);

            }
            return result;

        }
    }
}
