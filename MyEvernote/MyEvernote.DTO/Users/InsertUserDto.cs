using System.Web;

namespace MyEvernote.DTO.Users
{
    public class InsertUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public HttpPostedFileBase  ProfilImage { get; set; }
        public string ActivedGuid { get; set; }

        public string ImagePath { get; set; }

    }
}
