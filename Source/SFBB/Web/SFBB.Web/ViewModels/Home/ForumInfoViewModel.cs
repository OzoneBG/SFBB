namespace SFBB.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SFBB.Web.Infrastructure.Mapping;
    using SFBB.Data.Models;

    using AutoMapper;

    public class ForumInfoViewModel : IMapFrom<Forum>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TotalThreads { get; set; }

        public int TotalPosts { get; set; }

        public string LastPostName { get; set; }

        public int LastPostId { get; set; }

        public DateTime LastPostDate { get; set; }

        public string LastPostUser { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Forum, ForumInfoViewModel>()
                .ForMember(x => x.TotalThreads, opt => opt.MapFrom(z => z.Threads.Count))
                .ForMember(x => x.TotalPosts, opt => opt.MapFrom(z => z.Threads.Select(c => c.Replies.Count).FirstOrDefault()))
                .ForMember(x => x.LastPostId, opt => opt.MapFrom(z => z.Threads.OrderByDescending(p => p.CreatedOn).Select(k => k.Id).FirstOrDefault()))
                .ForMember(x => x.LastPostName, opt => opt.MapFrom(z => z.Threads.OrderByDescending(p => p.CreatedOn).FirstOrDefault().Title))
                .ForMember(x => x.LastPostDate, opt => opt.MapFrom(z => z.Threads.OrderByDescending(p => p.CreatedOn).Select(k => k.CreatedOn).FirstOrDefault()))
                .ForMember(x => x.LastPostUser, opt => opt.MapFrom(z => z.Threads.OrderByDescending(p => p.CreatedOn).FirstOrDefault().Author.UserName));
                
        }
    }
}
