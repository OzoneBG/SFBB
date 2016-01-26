namespace SFBB.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using SFBB.Data.Models;
    using SFBB.Web.Infrastructure.Mapping;

    public class IndexCategoriesForumsViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Forum> Forums { get; set; }
    }
}