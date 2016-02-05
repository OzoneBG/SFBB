namespace SFBB.Data.Models
{
    using SFBB.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Reply : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }

        public int ThreadId { get; set; }

        public virtual Thread Thread { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
