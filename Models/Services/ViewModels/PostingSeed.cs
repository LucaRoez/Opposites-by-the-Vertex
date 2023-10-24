﻿using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    /*
     * This model isolate the correct view model from his own layer, to facilitate their handling.
    */

    public abstract class PostingSeed : BaseViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Rate { get; set; }
        public PostingSeed()
        {
            Title = "";
            SubTitle = "";
            Body = "";
            Image = "";
            ImageAlt = "";
            PublicationDate = new();
            Author = "";
            Category = "";
            Rate = 0;
        }
    }
}
