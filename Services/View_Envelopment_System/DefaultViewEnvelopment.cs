using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
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

        public ViewClassViewModel GetEnvelopment(string controllerInput)
        {
            var Posts = _repository.DetailAll();
            var posts = _dataTruck.GetAllPostModels(Posts);

            ViewClassViewModel viewClass = new();
            switch (controllerInput)
            {
                case "Home":
                    viewClass.Class = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    break;

                default:
                    viewClass.Class = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    viewClass.ObjectClass.CurrentPostList = posts.OrderBy(p => p.Rate).ToList();
                    break;
            }
            return viewClass;
        }
    }
}
