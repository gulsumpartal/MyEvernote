using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEvernote.Entities
{
    [Table("Comments")]
    public class Comment:EntityBase
    {
        public int NoteId { get; set; }
        public int EvernoteUserId { get; set; }

        [Required,StringLength(300)]
        public string Text { get; set; }
        //public bool IsApproval { get; set; }

        public virtual Note Note { get; set; }
        public virtual EvernoteUser Owner { get; set; }
    }
}
