using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEvernote.Entities
{
    public class EntityBase
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }

        [Required,StringLength(30)]
        public string ModifiedUserName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
