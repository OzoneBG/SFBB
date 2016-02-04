namespace SFBB.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SFBB.Data.Common.Models;
    
    public class Thread : AuditInfo, IDeletableEntity
    {
        private ICollection<Reply> replies;

        public Thread()
        {
            this.replies = new HashSet<Reply>();
        }

        [Key]
        public int Id { get; set; }
        // to vmomenta tursi id 3 v bazata a to nema zatfa e null kak taka id 3
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }

        //moment
        public int ForumId { get; set; }
        public virtual Forum Forum { get; set; }

        public virtual ICollection<Reply> Replies
        {
            get { return this.replies; }
            set { this.replies = value; }
        }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
