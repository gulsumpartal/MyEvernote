using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEvernote.Entities
{
    [Table("Likes")]
    public class Liked
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NoteId { get; set; }
        public int EvernoteUserId { get; set; }

        public Note Note { get; set; }
        public EvernoteUser LikedUser { get; set; }
    }
}
