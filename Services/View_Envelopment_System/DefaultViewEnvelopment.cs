using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.Data_Tranfer;
using Opuestos_por_el_Vertice.Services.Searcher;

namespace Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System
{
    // remember always the default web site value is the Home
    public class DefaultViewEnvelopment : IViewEnvelopment
    {
        private readonly IRepository _repository;
        private readonly IDataTruck _dataTruck;
        private readonly ISearcher _searcher;
        public DefaultViewEnvelopment(IRepository repository, IDataTruck dataTruck, ISearcher searcher)
        {
            _repository = repository;
            _dataTruck = dataTruck;
            _searcher = searcher;
        }

        public async Task<ViewKindViewModel> GetStandardEnvelopment(string controllerInput)
        {
            await _repository.ArrangeDb();

            // This is the package object, where the internal logic is the same for all
            List<PostViewModel> posts = new();
            PostViewModel post = new();
            List<string> schemas = new();
            if (controllerInput == "Home" || controllerInput == "Privacy" ||
                controllerInput == "About") { posts = _searcher.GetViewModelList(GetSchemas(controllerInput), 5); }
            else { posts = _searcher.GetViewModelList(GetSchemas(controllerInput), 5); }

            // And this is the final shipping object, with his own web site logic
            ViewKindViewModel viewClass = new();
            switch (controllerInput)
            {
                case "Home":
                    viewClass.Kind = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "Privacy":
                    viewClass.Kind = new String("Privacy");
                    viewClass.WebTitle = "Privacy Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "About":
                    viewClass.Kind = new String("About");
                    viewClass.WebTitle = "About us";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                default:
                    viewClass.Kind = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;
            }

            viewClass.AsideData = _searcher.GetAsideSearch(posts, controllerInput, post, new SearchViewModel() { Action = controllerInput });

            return viewClass;
        }

        public async Task<ViewKindViewModel> GetModelEnvelopment(string controllerInput, int id, string postCategory)
        {
            List<PostViewModel> models = new();
            PostViewModel model = new();
            BasePost Post = new();
            List<string> schemas = new();

            if (controllerInput == "Post")
            {
                models = _searcher.GetViewModelList(GetSchemas(postCategory), 1);
                model = models.Find(p => p.Id == id); model ??= new();
            }
            else if (controllerInput == "Admin")
            {
                models = _searcher.GetViewModelList(GetSchemas(controllerInput), 5);
                if (id == 0) { model = new() { Category = postCategory }; } else { model = await _searcher.GetViewModel(id, postCategory); }
            }

            ViewKindViewModel viewClass = new();
            switch (controllerInput)
            {
                case "Post":
                    viewClass.Kind = new String("Post");
                    viewClass.WebTitle = String.Format("{0} - {1}", model.Title, postCategory);
                    viewClass.ObjectClass.CurrentPostList = models.OrderByDescending(p => p.Rate).ToList();
                    // update rating mechanism
                    model.Rate++; Post = await _repository.DetailOne(postCategory, id);
                    Post.Rate = model.Rate; await _repository.Update(Post);
                    viewClass.ObjectClass.CurrentPost = model;
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, model);
                    break;

                case "Admin":
                    viewClass.Kind = new String("Admin");
                    viewClass.WebTitle = "Admin Page";
                    viewClass.ObjectClass.CurrentPostList = models.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ObjectClass.CurrentPost = model;
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, model);
                    break;

                default:
                    viewClass.Kind = new String("Post");
                    viewClass.WebTitle = String.Format("{0} - {1}", model.Title, postCategory);
                    viewClass.ObjectClass.CurrentPostList = models.OrderByDescending(p => p.Rate).ToList();
                    model.Rate++; await _repository.DetailOne(model.Category, id);
                    Post.Rate = model.Rate; await _repository.Update(Post);
                    model.Rate++; await _repository.Update(_dataTruck.GetPostData(model));
                    viewClass.ObjectClass.CurrentPost = model;
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, model);
                    break;
            }

            viewClass.AsideData = _searcher.GetAsideSearch(models, controllerInput, model, new SearchViewModel() { Action = controllerInput });

            return viewClass;
        }

        public ViewKindViewModel GetSearchEnvelopment(string controllerInput, int page, SearchViewModel search, string extraData)
        {
            List<PostViewModel> posts = new();
            PostViewModel post = new();
            List<string> schemas = new();

            if (controllerInput.StartsWith("Index")) { posts = _searcher.GetViewModelList(GetSchemas(controllerInput), 5); }
            else { posts = _searcher.GetViewModelList(GetSchemas(extraData), 1); }

            ViewKindViewModel viewClass = new();
            string categorySearch = "";
            switch (controllerInput)
            {
                case "IndexSearch":
                    viewClass.Kind = new String("IndexSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    viewClass.CurrentPage = page;
                    categorySearch = "Index";
                    // this is the admin order for a specific modifying or deteting search
                    viewClass.AdminInfo.AdminMessage = extraData;
                    break;

                case "EventsSearch":
                    viewClass.Kind = new String("EventsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    viewClass.CurrentPage = page;
                    categorySearch = "Event";
                    break;

                case "NewsSearch":
                    viewClass.Kind = new String("NewsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    viewClass.CurrentPage = page;
                    categorySearch = "New";
                    break;

                case "ArtistsSearch":
                    viewClass.Kind = new String("ArtistsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    viewClass.CurrentPage = page;
                    categorySearch = "Artist";
                    break;

                case "AlbumsSearch":
                    viewClass.Kind = new String("AlbumsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    viewClass.CurrentPage = page;
                    categorySearch = "Album";
                    break;

                case "GenresSearch":
                    viewClass.Kind = new String("GenresSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    viewClass.CurrentPage = page;
                    categorySearch = "Genre";
                    break;

                default:
                    viewClass.Kind = new String("IndexSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderByDescending(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    viewClass.CurrentPage = page;
                    categorySearch = "Index";
                    // this is the admin order for a specific modifying or deteting search
                    viewClass.AdminInfo.AdminMessage = extraData;
                    break;
            }

            viewClass.SearchData = search;
            viewClass.SearchData.SearchList = _searcher.GetSearch(search.Search, categorySearch).OrderByDescending(p => p.PublicationDate).ToList();
            viewClass.SearchData.PaginationData = _searcher.GetPaginationData(viewClass.SearchData.SearchList.Count);
            viewClass.AsideData = _searcher.GetAsideSearch(posts, controllerInput, post, search);

            return viewClass;
        }

        // Db posting kind classification
        private string[] GetSchemas(string controller)
        {
            string[] schemas = new string[5];
            if (controller == "Home" || controller == "Privacy" || controller == "About" || controller == "Admin" || controller == "IndexSearch")
            {
                for (int i = 0; i < 5; i++)
                {
                    switch (i)
                    {
                        case 0: schemas[i] = "New"; break;
                        case 1: schemas[i] = "Event"; break;
                        case 2: schemas[i] = "Artist"; break;
                        case 3: schemas[i] = "Album"; break;
                        case 4: schemas[i] = "Genre"; break;
                        default: schemas[i] = "New"; break;
                    }
                }
            }
            else
            {
                schemas[0] = controller;
            }

            return schemas;
        }
        // supplemental view information
        private List<string> GetExtraInfo(string controllerInput, PostViewModel post)
        {
            List<string> extraInfo = new();

            if (controllerInput == "Home")
            {
                // amount of carousel turns, followed by images source, then their alternal description, then the carousel labels followed by their sublabels
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "Privacy")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "About")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "IndexSearch")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "EventsSearch")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "NewsSearch")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "ArtistsSearch")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "AlbumsSearch")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "GenresSearch")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else if (controllerInput == "Post")
            {
                // it doesn't need the GetHeroInfo for this case
                extraInfo.Add("1"); extraInfo.Add(post.Image); extraInfo.Add(post.ImageAlt);
                extraInfo.Add(post.Title); extraInfo.Add(post.SubTitle);
            }
            else if (controllerInput == "Admin")
            {
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }
            else
            {
                // amount of carousel turns, followed by images source, then their alternal description, then the carousel labels followed by their sublabels
                extraInfo = GetHeroInfo(controllerInput, extraInfo);
            }

            return extraInfo;
        }
        private List<string> GetHeroInfo(string controllerInput, List<string> extraInfo)
        {
            if (controllerInput.Equals("Home"))
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }

            return extraInfo;
        }
    }
}
