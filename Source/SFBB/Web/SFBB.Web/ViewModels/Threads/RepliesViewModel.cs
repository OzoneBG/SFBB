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

        //public string AuthorThreadsCount { get; set; }

        //public string AuthorRepliesCount { get; set; }

        public DateTime AuthorJoinDate { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Reply, RepliesViewModel>()
                .ForMember(x => x.AuthorName, opt => opt.MapFrom(z => z.Author.UserName))
                .ForMember(x => x.AuthorJoinDate, opt => opt.MapFrom(z => z.Author.CreatedOn));
        }
    }
}
