namespace SFBB.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;

    using SFBB.Web.Infrastructure.Mapping;
    using SFBB.Data.Models;

    using AutoMapper;

    public class IndexViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<ForumInfoViewModel> Forums { get; set; }
    }
}