namespace SFBB.Data.Models
{
    using System;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using SFBB.Data.Common.Models;

    [Table("Forums")]
    public class Forum : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
