using System;

namespace MyEvernote.DTO.Notes
{
    public class NoteListDto
    {
        public int NoteId { get; set; }
        public int LikeCount { get; set; }

        public string Title { get; set; }    
        public string Owner { get; set; }
        public string Text { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
