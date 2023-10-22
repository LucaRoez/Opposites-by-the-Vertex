using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.Data_Tranfer;

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

        public async Task<ViewKindViewModel> GetEnvelopment(string controllerInput, int id, string extraData)
        {
            // This is the package object, where the internal logic is the same for all
            List<PostViewModel> posts = new();
            PostViewModel post = new();
            List<string> schemas = new();
            if (controllerInput == "Home") { posts = GetViewModelList(GetSchemas(controllerInput), 5); }
            else if (controllerInput == "Privacy") { posts = GetViewModelList(GetSchemas(controllerInput), 5); }
            else if (controllerInput == "About") { posts = GetViewModelList(GetSchemas(controllerInput), 5); }
            else if (controllerInput == "IndexSearch") { posts = GetViewModelList(GetSchemas(controllerInput), 5); }
            else if (controllerInput == "EventsSearch") { posts = GetViewModelList(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "NewsSearch") { posts = GetViewModelList(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "ArtistsSearch") { posts = GetViewModelList(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "AlbumsSearch") { posts = GetViewModelList(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "GenresSearch") { posts = GetViewModelList(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "Post")
            {
                posts = GetViewModelList(GetSchemas(extraData+"sSearch"), 1);
                post = posts.Find(p => p.Id == id); if (post == null) { post = new(); }
            }
            else if (controllerInput == "Admin")
            {
                posts = GetViewModelList(GetSchemas(controllerInput), 5);
                if (id == 0) { post = new(); } else { post = await GetViewModel(id, extraData); }
            }
            else { posts = GetViewModelList(GetSchemas(controllerInput), 5); }

            // And this is the final shipping object, with his own web site logic
            ViewKindViewModel viewClass = new();
            switch (controllerInput)
            {
                case "Home":
                    viewClass.Kind = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "Privacy":
                    viewClass.Kind = new String("Privacy");
                    viewClass.WebTitle = "Privacy Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "About":
                    viewClass.Kind = new String("About");
                    viewClass.WebTitle = "About us";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "IndexSearch":
                    viewClass.Kind = new String("IndexSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "EventsSearch":
                    viewClass.Kind = new String("EventsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "NewsSearch":
                    viewClass.Kind = new String("NewsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "ArtistsSearch":
                    viewClass.Kind = new String("ArtistsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "AlbumsSearch":
                    viewClass.Kind = new String("AlbumsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "GenresSearch":
                    viewClass.Kind = new String("GenresSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;

                case "Post":
                    viewClass.Kind = new String("Post");
                    viewClass.WebTitle = String.Format("{0} - {1}", post.Title, post.Category);
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ObjectClass.CurrentPost = post;
                    viewClass.ExtraInfo = GetExtraInfo(extraData, post);
                    break;

                case "Admin":
                    viewClass.Kind = new String("Admin");
                    viewClass.WebTitle = "Admin Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.PublicationDate).ToList();
                    viewClass.ObjectClass.CurrentPost = post;
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    if (id == 0 && extraData != "") { viewClass.AdminMessage = extraData; }
                    break;

                default:
                    viewClass.Kind = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput, post);
                    break;
            }

            return viewClass;
        }

        // database comunication behavior
        private string[] GetSchemas(string controller)
        {
            string[] schemas = new string[5];
            if (controller == "Home" || controller == "Privacy" || controller == "About" || controller == "Admin")
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
            else if (controller == "IndexSearch")
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
            else if (controller == "EventsSearch")
            {
                schemas[0] = "Event";
            }
            else if (controller == "NewsSearch")
            {
                schemas[0] = "News";
            }
            else if (controller == "ArtistsSearch")
            {
                schemas[0] = "Artist";
            }
            else if (controller == "AlbumsSearch")
            {
                schemas[0] = "Album";
            }
            else if (controller == "GenresSearch")
            {
                schemas[0] = "Genre";
            }
            else
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
        private async Task<PostViewModel> GetViewModel(int id, string extraData) => _dataTruck.GetPostModel(await _repository.DetailOne(extraData, id));
        // supplemental view information
        private List<string> GetExtraInfo (string controllerInput, PostViewModel post)
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
