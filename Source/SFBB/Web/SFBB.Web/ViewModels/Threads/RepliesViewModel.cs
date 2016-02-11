namespace SFBB.Web.ViewModels.Threads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SFBB.Web.Infrastructure.Mapping;
    using SFBB.Data.Models;

    using AutoMapper;

    public class RepliesViewModel : IMapFrom<Reply>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        //End of standard mappings

        public string AuthorName { get; set; }

        public int AuthorThreadsCount { get; set; }

        public int AuthorRepliesCount { get; set; }

        public string Signature { get; set; }

        public DateTime AuthorJoinDate { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Reply, RepliesViewModel>()
                .ForMember(x => x.Signature, opt => opt.MapFrom(z => z.Author.Signature))
                .ForMember(x => x.AuthorThreadsCount, opt => opt.MapFrom(z => z.Author.Threads.Count))
                .ForMember(x => x.AuthorRepliesCount, opt => opt.MapFrom(z => z.Author.Replies.Count))
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(z => z.Author.UserName))
                .ForMember(x => x.AuthorJoinDate, opt => opt.MapFrom(z => z.Author.CreatedOn));
        }
    }
}
