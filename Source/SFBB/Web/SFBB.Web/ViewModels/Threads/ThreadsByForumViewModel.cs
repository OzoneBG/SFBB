namespace SFBB.Web.ViewModels.Threads
{
    using SFBB.Data.Models;
    using SFBB.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using AutoMapper;

    public class ThreadsByForumViewModel : IMapFrom<Forum>, IHaveCustomMappings
    {

        //Forum id
        public int Id { get; set; }

        //Forum title
        public string Title { get; set; }

        //Parent category name
        public string CategoryName { get; set; }
        
        //Thread info
        public ICollection<ThreadsInformationViewModel> Threads { get; set; }

        public void CreateMappings(IConfiguration config)
        {

            config.CreateMap<Forum, ThreadsByForumViewModel>()
                .ForMember(t => t.CategoryName, opt => opt.MapFrom(z => z.Category.Title));
        }
    }
}