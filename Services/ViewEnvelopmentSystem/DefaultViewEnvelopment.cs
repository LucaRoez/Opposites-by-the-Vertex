using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.DataTranfer;
using Opuestos_por_el_Vertice.Services.Searcher;

namespace Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem
{
    // remember always the default web site value is the Home
    public class DefaultViewEnvelopment : IViewEnvelopment
    {
        private readonly IRepository _repository;
        public DefaultViewEnvelopment(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ViewKindViewModel> GetViewEnvelopment(string controllerInput)
        {
            await _repository.UnbendDb();

            /*   taking both objects needed, only one flow path   */
            List<PostViewModel> posts = new();
            StaticSearcher.Main(controllerInput).Categories.ToList()
                .ForEach(category => { posts.AddRange(DataConverter.GetAllViewModels(_repository.DetailAll(category))); });

            var viewClass = new ViewKindViewModel(
                posts, null,
                StaticSearcher.Main(controllerInput).Hero,
                StaticSearcher.Main(controllerInput).Aside,
                null,
                StaticSearcher.Main(controllerInput).Admin
                );

            return viewClass;
        }

        public async Task<ViewKindViewModel> GetViewEnvelopment(string controllerInput, int id, string postCategory)
        {
            /*   taking both objects needed with their heros, all features are unique by controller input variable   */
            List<PostViewModel> posts = new(); PostViewModel? post = null;
            if (!postCategory.Equals("")) { post = DataConverter.GetViewModel(await _repository.DetailOne(postCategory, id)); }
            string[] categories = StaticSearcher.Main(controllerInput).Categories;
            HeroViewModel? hero = StaticSearcher.Main(controllerInput).Hero;
            if (categories[0] == "Post" || categories[0].Equals("Admin") && !postCategory.Equals(""))
            {
                categories = new string[1]; categories[0] = post.Category ?? postCategory;
                if (categories[0] == "Post")
                {
                    hero.ImageSources.Add(post.Image); hero.ImageAltSources.Add(post.ImageAlt); hero.Titles.Add(post.Title); hero.SubTitles.Add(post.SubTitle);
                }
            }
            else if (categories[0].Equals("Admin") && postCategory.Equals("")) { categories = StaticSearcher.Main("General").Categories; }

            categories.ToList()
                .ForEach(category => { posts.AddRange(DataConverter.GetAllViewModels(_repository.DetailAll(category))); });

            var viewClass = new ViewKindViewModel(
                posts, post, hero,
                StaticSearcher.Main(controllerInput).Aside,
                null,
                StaticSearcher.Main(controllerInput).Admin
                );

            return viewClass;
        }

        public ViewKindViewModel GetViewEnvelopment(string controllerInput, int page, SearchViewModel search, string postsCategory)
        {
            /*   taking both objects needed, with two flow path   */
            List<PostViewModel> posts = new();
            if (postsCategory.Equals(""))
            {
                StaticSearcher.Main(controllerInput).Categories.ToList()
                    .ForEach(category => { posts.AddRange(DataConverter.GetAllViewModels(_repository.DetailAll(category))); });
                postsCategory = controllerInput;
            }
            else { posts.AddRange(DataConverter.GetAllViewModels(_repository.DetailAll(postsCategory))); }

            /*   applying search settings   */
            SearchViewModel thisSearch = StaticSearcher.Main(postsCategory).Searcher;
            thisSearch = StaticSearcher.FillSearcher(search.Search.Trim().ToLower(), thisSearch.Action, posts);


            var viewClass = new ViewKindViewModel(
                posts, null,
                StaticSearcher.Main(postsCategory).Hero,
                StaticSearcher.Main(postsCategory).Aside,
                thisSearch,
                StaticSearcher.Main(postsCategory).Admin
                );

            return viewClass;
        }
    }
}
