namespace SFBB.Web.ViewModels.Threads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SFBB.Web.Infrastructure.Mapping;
    using SFBB.Data.Models;

    using AutoMapper;

    public class ThreadsViewModel : IMapFrom<Thread>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        //End of standard mappings

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string ForumName { get; set; }

        public int ForumId { get; set; }

        //End of breadcrumb mapping

        public string AuthorName { get; set; }

        public int AuthorThreadsCount { get; set; }

        public int AuthorRepliesCount { get; set; }

        public DateTime AuthorJoinDate { get; set; }

        public string Signature { get; set; }

        public ICollection<RepliesViewModel> Replies { get; set; }


        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Thread, ThreadsViewModel>()
                .ForMember(x => x.ForumName, opt => opt.MapFrom(z => z.Forum.Title))
                .ForMember(x => x.ForumId, opt => opt.MapFrom(z => z.ForumId))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(z => z.Forum.Category.Title))
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(z => z.Forum.CategoryId))
                .ForMember(x => x.Signature, opt => opt.MapFrom(z => z.Author.Signature))
                .ForMember(x => x.AuthorThreadsCount, opt => opt.MapFrom(z => z.Author.Threads.Count))
                .ForMember(x => x.AuthorRepliesCount, opt => opt.MapFrom(z => z.Author.Replies.Count))
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(z => z.Author.UserName))
                .ForMember(x => x.AuthorJoinDate, opt => opt.MapFrom(z => z.Author.CreatedOn));
        }
    }
}