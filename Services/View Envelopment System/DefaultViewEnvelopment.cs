namespace Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System
{
    public class DefaultViewEnvelopment : IViewEnvelopment
    {
        public ViewClassViewModel GetEnvelopment(string controllerInput)
        {
            ViewClassViewModel viewClass = new();
            switch (controllerInput)
            {
                case "Home":
                    viewClass.Class = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    break;

                default:
                    viewClass.Class = new String("Home");
                    viewClass.WebTitle = "Home Page";
                    break;
            }
            return viewClass;
        }
    }
}
