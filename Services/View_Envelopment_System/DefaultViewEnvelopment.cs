using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.Data_Tranfer;

namespace Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System
{
    public class DefaultViewEnvelopment : IViewEnvelopment
    {
        private readonly IRepository _repository;
        private readonly IDataTruck _dataTruck;
        public DefaultViewEnvelopment(IRepository repository, IDataTruck dataTruck)
        {
            _repository = repository;
            _dataTruck = dataTruck;
        }

        public ViewKindViewModel GetEnvelopment(string controllerInput)
        {
            List<PostViewModel> posts = new();
            List<string> schemas = new();
            if (controllerInput == "Home") { posts = IterateSchemas(GetSchemas(controllerInput), 5); }

            ViewKindViewModel viewClass = new();
            switch (controllerInput)
            {
                case "Home":
                    viewClass.Kind = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    break;

                default:
                    viewClass.Kind = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
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
            for (int i = 0; i < iterations; i++) { if (i == 0) { Posts = _repository.DetailAll(schemas[i]); } else { Posts.AddRange(_repository.DetailAll(schemas[i])); } }
                
            return _dataTruck.GetAllPostModels(Posts);
        }
    }
}
