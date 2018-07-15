namespace MyEvernote.DTO.Users
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ProfileImagePath { get; set; }

        public bool IsAdmin { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
    }
}
