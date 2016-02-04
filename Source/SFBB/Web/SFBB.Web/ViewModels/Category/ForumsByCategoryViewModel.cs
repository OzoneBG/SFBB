namespace SFBB.Web.ViewModels.Category
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using SFBB.Web.Infrastructure.Mapping;
    using SFBB.Data.Models;

    public class ForumsByCategoryViewModel : IMapFrom<Category>
    {

        public string Title { get; set; }

        public ICollection<ForumInfoViewModel> Forums { get; set; } 
    }
}