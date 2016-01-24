namespace SFBB.Data.Models
{
    using SFBB.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Category : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
