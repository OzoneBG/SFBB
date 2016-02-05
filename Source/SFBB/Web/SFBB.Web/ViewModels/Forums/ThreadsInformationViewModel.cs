namespace SFBB.Web.ViewModels.Threads
{
    using System;
    using System.Linq;
    using SFBB.Data.Models;
    using SFBB.Web.Infrastructure.Mapping;
    using AutoMapper;

    public class ThreadsInformationViewModel : IMapFrom<Thread>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Views { get; set; }

        public int ReplyCount { get; set; }

        public string AuthorName { get; set; }
        
        public string DateStarted { get; set; }

        public string LastPostBy { get; set; }

        public DateTime LastPostDate { get; set; }
    
       public void CreateMappings(IConfiguration config)
       {
           config.CreateMap<Thread, ThreadsInformationViewModel>()
               .ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.UserName)) //Map AuthorName
               .ForMember(x => x.ReplyCount, opt => opt.MapFrom(x => x.Replies.Count)) //Map ReplyCount
               .ForMember(x => x.DateStarted, opt => opt.MapFrom(x => x.CreatedOn.ToString())) //Map ThreadDateStarted
               .ForMember(x => x.LastPostBy, opt => opt.MapFrom(x => x.Replies.OrderByDescending(y => y.CreatedOn).Select(y => y.Author.UserName).FirstOrDefault()))
               .ForMember(x => x.LastPostDate, opt => opt.MapFrom(x => x.Replies.OrderByDescending(z => z.CreatedOn).Select(y => y.CreatedOn).FirstOrDefault()));
       }
    }
}