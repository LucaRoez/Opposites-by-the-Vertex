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

        public ViewKindViewModel GetEnvelopment(string controllerInput, int id, string postCategory)
        {
            // This is the package object, where the internal logic is the same for all
            List<PostViewModel> posts = new();
            PostViewModel post = new();
            List<string> schemas = new();
            if (controllerInput == "Home") { posts = IterateSchemas(GetSchemas(controllerInput), 5); }
            else if (controllerInput == "Privacy") { posts = IterateSchemas(GetSchemas(controllerInput), 5); }
            else if (controllerInput == "About") { posts = IterateSchemas(GetSchemas(controllerInput), 5); }
            else if (controllerInput == "IndexSearch") { posts = IterateSchemas(GetSchemas(controllerInput), 5); }
            else if (controllerInput == "EventsSearch") { posts = IterateSchemas(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "NewsSearch") { posts = IterateSchemas(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "ArtistsSearch") { posts = IterateSchemas(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "AlbumsSearch") { posts = IterateSchemas(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "GenresSearch") { posts = IterateSchemas(GetSchemas(controllerInput), 1); }
            else if (controllerInput == "Post")
            {
                posts = IterateSchemas(GetSchemas(postCategory+"sSearch"), 1);
                post = posts.Find(p => p.Id == id);
            }
            else { posts = IterateSchemas(GetSchemas(controllerInput), 5); }

            // And this is the final shipping object, with his own web site logic
            ViewKindViewModel viewClass = new();
            switch (controllerInput)
            {
                case "Home":
                    viewClass.Kind = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "Privacy":
                    viewClass.Kind = new String("Privacy");
                    viewClass.WebTitle = "Privacy Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "About":
                    viewClass.Kind = new String("About");
                    viewClass.WebTitle = "About us";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "IndexSearch":
                    viewClass.Kind = new String("IndexSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "EventsSearch":
                    viewClass.Kind = new String("EventsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "NewsSearch":
                    viewClass.Kind = new String("NewsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "ArtistsSearch":
                    viewClass.Kind = new String("ArtistsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "AlbumsSearch":
                    viewClass.Kind = new String("AlbumsSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "GenresSearch":
                    viewClass.Kind = new String("GenresSearch");
                    viewClass.WebTitle = "Search Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;

                case "Post":
                    viewClass.Kind = new String("Post");
                    viewClass.WebTitle = String.Format("{0} - {1}", post.Title, post.Category);
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ObjectClass.CurrentPost = post;
                    viewClass.ExtraInfo = GetExtraInfo(postCategory);
                    break;

                default:
                    viewClass.Kind = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    viewClass.ExtraInfo = GetExtraInfo(controllerInput);
                    break;
            }

            return viewClass;
        }

        private string[] GetSchemas(string controller)
        {
            string[] schemas = new string[5];
            if (controller == "Home")
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
            else if (controller == "Privacy")
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
            else if (controller == "About")
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
        private List<PostViewModel> IterateSchemas(string[] schemas, int iterations)
        {
            List<BasePost> Posts = new();
            for (int i = 0; i < iterations; i++)
            {
                if (i == 0) { Posts = _repository.DetailAll(schemas[i]); } else { Posts.AddRange(_repository.DetailAll(schemas[i])); } 
            }
                
            return _dataTruck.GetAllPostModels(Posts);
        }
        private List<string> GetExtraInfo (string controllerInput)
        {
            List<string> extraInfo = new();

            if (controllerInput == "Home")
            {
                // amount of carousel turns, followed by images source, then their alternal description, then the carousel labels followed by their sublabels
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "Privacy")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "About")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "IndexSearch")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "EventsSearch")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "NewsSearch")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "ArtistsSearch")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "AlbumsSearch")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "GenresSearch")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else if (controllerInput == "Post")
            {
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }
            else
            {
                // amount of carousel turns, followed by images source, then their alternal description, then the carousel labels followed by their sublabels
                extraInfo.Add("2"); extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
                extraInfo.Add(""); extraInfo.Add("");
            }

            return extraInfo;
        }
    }
}
