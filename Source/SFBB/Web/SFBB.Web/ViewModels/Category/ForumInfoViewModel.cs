namespace SFBB.Web.ViewModels.Category
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using SFBB.Web.Infrastructure.Mapping;
    using SFBB.Data.Models;

    public class ForumInfoViewModel : IMapFrom<Forum>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TotalThreads { get; set; }

        public int TotalReplies { get; set; }

        public string LastPostName { get; set; }

        public string LastPostUser { get; set; }

        public DateTime LastPostDate { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Forum, ForumInfoViewModel>()
                .ForMember(x => x.TotalThreads, opt => opt.MapFrom(z => z.Threads.Count))
                .ForMember(x => x.TotalReplies, opt => opt.MapFrom(z => z.Threads.Select(p => p.Replies.Count).FirstOrDefault()))
                .ForMember(x => x.LastPostName, opt => opt.MapFrom(z => z.Threads.OrderByDescending(p => p.CreatedOn).FirstOrDefault().Title))
                .ForMember(x => x.LastPostUser, opt => opt.MapFrom(z => z.Threads.OrderByDescending(p => p.CreatedOn).FirstOrDefault().Author.UserName))
                .ForMember(x => x.LastPostDate, opt => opt.MapFrom(z => z.Threads.OrderByDescending(p => p.CreatedOn).Select(k => k.CreatedOn).FirstOrDefault()));
        }
    }
}
