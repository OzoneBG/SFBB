﻿namespace SFBB.Data.Models
{
    using SFBB.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
