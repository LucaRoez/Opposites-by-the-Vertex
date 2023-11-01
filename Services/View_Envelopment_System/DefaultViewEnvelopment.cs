using Microsoft.Extensions.Hosting;
using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.Data_Tranfer;
using System.Collections.Generic;

namespace Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System
{
    // remember always the default web site value is the Home
    public class DefaultViewEnvelopment : IViewEnvelopment
    {
        private readonly IRepository _repository;
        private readonly IDataTruck _dataTruck;
        public DefaultViewEnvelopment(IRepository repository, IDataTruck dataTruck)
        {
            _repository = repository;
            _dataTruck = dataTruck;
        }

        public async Task<ViewKindViewModel> GetStandardEnvelopment(string controllerInput)
        {
            await _repository.ArrangeDb();

            // This is the package object, where the internal logic is the same for all
            List<PostViewModel> posts = new();
            PostViewModel post = new();
            List<string> schemas = new();
            if (controllerInput == "Home" || controllerInput == "Privacy" ||
                controllerInput == "About") { posts = GetViewModelList(GetSchemas(controllerInput), 5); }
            else { posts = GetViewModelList(GetSchemas(controllerInput), 5); }

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

            return viewClass;
        }

        public async Task<ViewKindViewModel> GetPostEnvelopment(string controllerInput, int id, string postCategory)
        {
            List<PostViewModel> models = new();
            PostViewModel model = new();
            BasePost Post = new();
            List<string> schemas = new();

            if (controllerInput == "Post")
            {
                models = GetViewModelList(GetSchemas(postCategory), 1);
                model = models.Find(p => p.Id == id); model ??= new();
            }
            else if (controllerInput == "Admin")
            {
                await _repository.ArrangeDb();
                models = GetViewModelList(GetSchemas(controllerInput), 5);
                if (id == 0) { model = new(); } else { model = await GetViewModel(id, postCategory); }
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

            return viewClass;
        }

        public ViewKindViewModel GetSearchEnvelopment(string controllerInput, int page, SearchViewModel search, string extraData)
        {
            List<PostViewModel> posts = new();
            PostViewModel post = new();
            List<string> schemas = new();

            if (controllerInput.StartsWith("Index")) { posts = GetViewModelList(GetSchemas(controllerInput), 5); }
            else { posts = GetViewModelList(GetSchemas(extraData), 1); }

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
            viewClass.SearchData.SearchList = GetSearch(search.Search, categorySearch).OrderByDescending(p => p.PublicationDate).ToList();
            viewClass.SearchData.PaginationData = GetPaginationData(viewClass.SearchData.SearchList.Count);

            return viewClass;
        }

        // database comunication behavior
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
        private List<PostViewModel> GetViewModelList(string[] schemas, int iterations)
        {
            List<BasePost> Posts = new();
            for (int i = 0; i < iterations; i++)
            {
                if (i == 0) { Posts = _repository.DetailAll(schemas[i]); } else { Posts.AddRange(_repository.DetailAll(schemas[i])); }
            }

            return _dataTruck.GetAllPostModels(Posts);
        }
        private async Task<PostViewModel> GetViewModel(int id, string postCategory) => _dataTruck.GetPostModel(await _repository.DetailOne(postCategory, id));
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
        // search mechanism
        private List<PostViewModel> GetSearch(string search, string category)
        {
            List<BasePost> finalSearch = new();
            if (search == "" || search == null)
            {
                if (category == "Index")
                {
                    finalSearch = GlobalSearch(finalSearch, "");
                }
                else { finalSearch = GetSearchList(category, finalSearch, ""); }
            }
            else
            {
                if (category == "Index")
                {
                    finalSearch = GlobalSearch(finalSearch, search);
                }
                else { finalSearch = GetSearchList(category, finalSearch, search); }
            }

            return _dataTruck.GetAllPostModels(finalSearch);
        }
        private List<BasePost> GlobalSearch(List<BasePost> finalSearch, string search)
        {
            for (int i = 0; i< 5; i++)
            {
                switch (i)
                {
                    case 4: finalSearch = GetSearchList("Genre", finalSearch, search); break;

                    case 3: finalSearch = GetSearchList("Album", finalSearch, search); break;

                    case 2: finalSearch = GetSearchList("Artist", finalSearch, search); break;

                    case 1: finalSearch = GetSearchList("Event", finalSearch, search); break;

                    default: finalSearch = GetSearchList("New", finalSearch, search); break;
                }
            }

            return finalSearch;
        }
        private List<BasePost> GetSearchList(string memory, List<BasePost> List, string search)
        {
            if (search != "")
            {
                search = search.Trim().ToLower();
                string searchStart = ""; string searchEnd = "";
                for (int i = 0; i < search.Length / 2; i++) { searchStart += search[i]; }
                for (int i = search.Length / 2; i < search.Length; i++) { searchEnd += search[i]; }

                if (searchStart == "" || searchEnd == "") { List.AddRange(_repository.DetailAll(memory).Where(p => p.Title.ToLower().Contains(search)).ToList()); }
                else
                {
                    List.AddRange(_repository.DetailAll(memory).Where(p => p.Title.ToLower().Contains(search) || p.Title.ToLower().Contains(searchStart) || p.Title.ToLower().Contains(searchEnd)).ToList());
                }
            }
            else { List.AddRange(_repository.DetailAll(memory)); }

            return List;
        }
        // pagination loads
        private List<int> GetPaginationData(int totalPosts)
        {
            List<int> paginationData = new();
            if (totalPosts == 0) { totalPosts++; }
            var divider = 10;
            var totalPages = totalPosts / divider;
            var rest = totalPosts % divider;
            if (rest > 0) { totalPages++; }

            paginationData.Add(totalPosts); paginationData.Add(totalPages); paginationData.Add(rest);
            return paginationData;
        }
    }
}
