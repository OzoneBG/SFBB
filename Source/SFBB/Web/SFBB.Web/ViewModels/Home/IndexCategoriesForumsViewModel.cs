namespace SFBB.Web.ViewModels.Home
{
    using SFBB.Data.Models;
    using SFBB.Web.Infrastructure.Mapping;

    public class IndexCategoriesForumsViewModel : IMapFrom<Category>
    {
        public string Title { get; set; }
    }
}