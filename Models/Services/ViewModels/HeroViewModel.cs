using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public class HeroViewModel
    {
        public int ImagesAmount { get; set; }
        public List<string> ImageSources { get; set; }
        public List<string> ImageAltSources { get; set; }
        public List<string> Titles { get; set; }
        public List<string> SubTitles { get; set; }

        public HeroViewModel()
        {
            ImagesAmount = 1;
            ImageSources = new();
            ImageAltSources = new();
            Titles = new();
            SubTitles = new();
        }

        public void GetHeroData(string controllerInput, PostViewModel post)
        {
            List<string> imgSources = new();
            List<string> imgAlt = new();
            List<string> titles = new();
            List<string> subs = new();
            if (controllerInput == "Home")
            {
                imgSources.Add("/img/testing/home.jpg");
                imgAlt.Add("");
                titles.Add("Welcome to Opposites by the Vertex");
                subs.Add("The page where you can find all about METAL!!!");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "Privacy")
            {
                imgSources.Add("/img/testing/home.jpg");
                imgAlt.Add("");
                titles.Add("Our Privicy Policies");
                subs.Add("HEEEERE!!!");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "About")
            {
                imgSources.Add("/img/testing/home.jpg");
                imgAlt.Add("");
                titles.Add("Who are we?");
                subs.Add("HEEEERE!!!");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "IndexSearch")
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("General Search");
                subs.Add("");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "EventsSearch")
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Events and Shows Search");
                subs.Add("");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "NewsSearch")
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Last and BREAKING News Search");
                subs.Add("");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "ArtistsSearch")
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Artists and Bands Search");
                subs.Add("");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "AlbumsSearch")
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Albums, EP's and Discographies Search");
                subs.Add("");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "GenresSearch")
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Genres and Subgenres Search");
                subs.Add("");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "Post")
            {
                imgSources.Add(post.Image);
                imgAlt.Add(post.ImageAlt);
                titles.Add(post.Title);
                subs.Add(post.SubTitle);

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else if (controllerInput == "Admin")
            {
                imgSources.Add("/img/testing/admin.jpg");
                imgAlt.Add("");
                titles.Add("Administrator Page");
                subs.Add("Make some CRUDs operations here.");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
            else
            {
                imgSources.Add("/img/testing/home.jpg");
                imgAlt.Add("");
                titles.Add("Welcome to Opposites by the Vertex");
                subs.Add("The page where you can find all about METAL!!!");

                ImagesAmount = 1;
                ImageSources.AddRange(imgSources);
                ImageAltSources.AddRange(imgAlt);
                Titles.AddRange(titles);
                SubTitles.AddRange(subs);
            }
        }
    }
}
