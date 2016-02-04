namespace SFBB.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using SFBB.Data.Common.Models;

    public class Category : AuditInfo, IDeletableEntity
    {
        private ICollection<Forum> forums;

        public Category()
        {
            this.forums = new HashSet<Forum>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Forum> Forums
        {
            get { return this.forums; }
            set { this.forums = value; }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
