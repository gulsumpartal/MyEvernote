using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEvernote.Entities
{
    [Table("Categories")]
    public class Category : EntityBase
    {
        [Required,StringLength(50)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }

        public virtual List<Note> Notes { get; set; }
        public Category()
        {
            Notes = new List<Note>();
        }
    }
}
