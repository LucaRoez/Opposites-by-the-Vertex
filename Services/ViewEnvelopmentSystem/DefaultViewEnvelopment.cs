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
            string refinedInput = StaticSearcher.ControllerFunctionsIdentifier.RefineControllerInput(controllerInput);
            var centralInfo = StaticSearcher.Body(refinedInput);

            /*   only one object and flow path for all functions needed   */
            List<PostViewModel> posts = new();
            centralInfo.Categories.ToList()
                .ForEach(category => { posts.AddRange(DataConverter.GetAllViewModels(_repository.DetailAll(category))); });

            /*   aside settings   */
            AsideViewModel aside = centralInfo.Aside;
            aside.AsidesList.Add(posts);

            var viewClass = new ViewKindViewModel(
                posts, null,
                centralInfo.Hero, aside,
                null, centralInfo.Admin
                );

            return viewClass;
        }

        public async Task<ViewKindViewModel> GetViewEnvelopment(string controllerInput, int id, string postCategory)
        {
            string refinedInput = StaticSearcher.ControllerFunctionsIdentifier.RefineControllerInput(controllerInput);
            var centralInfo = StaticSearcher.Body(refinedInput);

            /*   taking both objects needed, with two flow paths   */
            List<PostViewModel> posts = new(); PostViewModel? post = null;
            if (!postCategory.Equals("")) { post = DataConverter.GetViewModel(await _repository.DetailOne(postCategory, id)); }
            string[] categories = centralInfo.Categories;
            categories.ToList()
                .ForEach(category => { posts.AddRange(DataConverter.GetAllViewModels(_repository.DetailAll(category))); });

            /*   hero settings, all features are uniques according to controller input   */
            HeroViewModel hero = StaticSearcher.Body(controllerInput).Hero;
            if (controllerInput == "Post")
            {
                hero.ImageSources.Clear(); hero.ImageAltSources.Clear(); hero.Titles.Clear(); hero.SubTitles.Clear();
                hero.ImageSources.Add(post.Image); hero.ImageAltSources.Add(post.ImageAlt);
                hero.Titles.Add(post.Title); hero.SubTitles.Add(post.SubTitle);
            }

            /*   aside settings   */
            AsideViewModel aside = centralInfo.Aside;
            aside.AsidesList.Add(posts);

            var viewClass = new ViewKindViewModel(
                posts, post,
                hero, aside,
                null, centralInfo.Admin
                );

            return viewClass;
        }

        public ViewKindViewModel GetViewEnvelopment(string controllerInput, int page, SearchViewModel thisSearch, string postsCategory)
        {
            string refinedInput = StaticSearcher.ControllerFunctionsIdentifier.RefineControllerInput(controllerInput);
            var centralInfo = StaticSearcher.Body(refinedInput);

            /*   taking posts needed   */
            List<PostViewModel> posts = new();
            string[] categories = centralInfo.Categories;
            categories.ToList()
                .ForEach(category => { posts.AddRange(DataConverter.GetAllViewModels(_repository.DetailAll(category))); });

            /*   search settings   */
            SearchViewModel search = centralInfo.Searcher;
            search = StaticSearcher.SearchFunctions.FillSearcher(thisSearch.Search.Trim().ToLower(), search.Action, posts);

            /*   aside settings   */
            AsideViewModel aside = centralInfo.Aside;
            aside.AsidesList.Add(posts); aside.SearchData = search;

            var viewClass = new ViewKindViewModel(
                posts, null,
                centralInfo.Hero,
                aside,
                search,
                centralInfo.Admin
                );

            return viewClass;
        }
    }
}
