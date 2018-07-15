using MyEvernote.Common.Helper;
using MyEvernote.DataAccessLayer.EFRepositories;
using MyEvernote.DTO.Response;
using MyEvernote.DTO.Users;
using MyEvernote.Entities;

namespace MyEvernote.BusinessLayer.Validation.User
{
    public class UserValidator
    {
        private readonly Repository<EvernoteUser> repo;

        public UserValidator()
        {
            repo = new Repository<EvernoteUser>();
        }

        public ResponseMessage<RegisterUserDto> SameUserExists(RegisterUserDto dto)
        {
            ResponseMessage<RegisterUserDto> result = new ResponseMessage<RegisterUserDto>();

            if (SameUserExitsByMail(dto.Email))
            {
                result.IsSuccess = false;
                result.Messages.Add("Sistemde bu mail adresine sahip başka bir kullanıcı mevcut!");
            }
            if (SameUserExitsByUserName(dto.Username))
            {
                result.IsSuccess = false;
                result.Messages.Add("Sistemde bu kullanıcı sahip başka bir kullanıcı mevcut!");
            }
            return result;
        }


        public ResponseMessage<RegisterUserDto> MailIsValid(string mail)
        {
            ResponseMessage<RegisterUserDto> result = new ResponseMessage<RegisterUserDto>();

            if (!Utility.MailIsValid(mail.Trim()))
            {
                result.IsSuccess = false;
                result.Messages.Add("Girilen Mail Adresi Geçersiz!");
            }
            return result;
        }

        public ResponseMessage<InsertUserDto> ValidateForActivedUser(string activedGuid)
        {
            ResponseMessage<InsertUserDto> result = new ResponseMessage<InsertUserDto>();

            if (!UserIsExistByActivedGuid(activedGuid))
            {
                result.IsSuccess = false;
                result.Messages.Add("İlgili aktivasyon koduna ait kullanıcı bilgisi bulunmamaktadır!");
                return result;
            }
            if (UserIsActive(activedGuid))
            {
                result.IsSuccess = false;
                result.Messages.Add("İlgili aktivasyon koduna ait kullanıcı bilgisi aktive edilmiştir!");
                return result;
            }
            return result;
        }

        private bool SameUserExitsByUserName(string username)
        {
            return repo.Any(p => p.Username == username && p.IsDeleted == false);
        }

        private bool SameUserExitsByMail(string mail)
        {
            return repo.Any(p => p.Email == mail && p.IsDeleted == false);
        }


        private bool UserIsExistByActivedGuid(string activedGuid)
        {
            var result = repo.Any(p => p.ActivateGuid.ToString() == activedGuid);
            return result;
        }
        private bool UserIsActive(string activedGuid)
        {
            var result = repo.Any(p => p.ActivateGuid.ToString() == activedGuid && p.IsActive);
            return result;
        }
    }
}
