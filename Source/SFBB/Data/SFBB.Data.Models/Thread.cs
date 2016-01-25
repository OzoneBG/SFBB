namespace SFBB.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SFBB.Data.Common.Models;
    
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
