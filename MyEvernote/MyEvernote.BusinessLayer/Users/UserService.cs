using MyEvernote.BusinessLayer.Response;
using MyEvernote.DataAccessLayer.EFRepositories;
using MyEvernote.DTO.Users;
using MyEvernote.Entities;
using System;
using System.Linq;

namespace MyEvernote.BusinessLayer.Users
{
    public class UserService
    {
        private Repository<EvernoteUser> repo;
        public UserService()
        {
            repo = new Repository<EvernoteUser>();
        }
        private EvernoteUser GetEvernoteUser(string userName, string password)
        {
            EvernoteUser result = repo.Find(p => p.IsActive == true && p.Username == userName.Trim() && p.Password == password.Trim());

            return result;
        }

        public ResponseMessage<UserDto>  GetUserDetails(string username, string password)
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
                        Username= evernoteUser.Username
                    };
                    result.IsSuccess = true;
                    result.Result = data;
                }
                else
                {
                    result.Errors.Add("Kullanıcı bilgileri aktive edilmemiş lütfen mail adresinizi kontrol ediniz!");
                }
            }
            else
            {               
                result.Errors.Add("Kullanıcı Adı veya Şifre Hatalı!");             
            }
            return result;
        }

        public ResponseMessage<RegisterUserDto> AddUser(RegisterUserDto dto)
        {
            var result = new ResponseMessage<RegisterUserDto>();

            Validation(dto, result);

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

                if (affectedRowCount > 0)
                {
                    //mail gönderme işlemleri
                }

            }

            return result;
        }

        private void Validation(RegisterUserDto dto, ResponseMessage<RegisterUserDto> result)
        {
            if (SameUserExitsByMail(dto.Email))
            {
                result.IsSuccess = false;
                result.Errors.Add("Sistemde bu mail adresine sahip başka bir kullanıcı mevcut!");
            }
            if (SameUserExitsByUserName(dto.Username))
            {
                result.IsSuccess = false;
                result.Errors.Add("Sistemde bu kullanıcı sahip başka bir kullanıcı mevcut!");
            }
        }

        private bool SameUserExitsByUserName(string username)
        {
            return repo.ListQueryableWithWhere(p => p.Username == username && p.IsDeleted == false).Any();
        }

        private bool SameUserExitsByMail(string mail)
        {
            return repo.ListQueryableWithWhere(p => p.Email == mail && p.IsDeleted == false).Any();
        }
    }
}
