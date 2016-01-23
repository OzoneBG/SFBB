namespace SFBB.Data.Models
{
    using SFBB.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Thread : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
