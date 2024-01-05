using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopment;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.ViewEnvelopment;

namespace Opuestos_por_el_Vertice.Services.ViewEnvelopmentSystem
{
    public static class ControllerCoreUtilities
    {
        private static readonly string[] _categories = new[] { "New", "Event", "Artist", "Album", "Genre" };
        private static readonly Dictionary<string, Func<List<string>, List<string>, List<string>, List<string>, HeroViewModel>>
            _heroFuncs = new()
        {
            { "Home", HeroFunctions.GetHomeHero },
            { "Privacy", HeroFunctions.GetPrivacyHero },
            { "About", HeroFunctions.GetAboutHero },
            { "Account", HeroFunctions.GetAccountHero },
            { "IndexSearch", HeroFunctions.GetSearchHero },
            { "NewsSearch", HeroFunctions.GetNewsHero },
            { "EventsSearch", HeroFunctions.GetEventsHero },
            { "ArtistsSearch", HeroFunctions.GetArtistsHero },
            { "AlbumsSearch", HeroFunctions.GetAlbumsHero },
            { "GenresSearch", HeroFunctions.GetGenresHero },
            { "Post", HeroFunctions.GetPostHero },
            { "General", HeroFunctions.GetHomeHero },
            { "Admin", HeroFunctions.GetAdminHero },
            { "New", HeroFunctions.GetNewsHero },
            { "Event", HeroFunctions.GetEventsHero },
            { "Artist", HeroFunctions.GetArtistsHero },
            { "Album", HeroFunctions.GetAlbumsHero },
            { "Genre", HeroFunctions.GetGenresHero }
        };
        private static readonly Dictionary<string, string[]> _pageInfo = new()
        {
            { "Home", new[]{ "Home", "Home Page" } },
            { "Privacy", new[]{ "Privacy", "Privacy Policies Page" } },
            { "About", new[]{ "About", "About us" } },
            { "Account", new[]{ "Logging", "Account Page" } },
            { "IndexSearch", new[]{ "IndexSearch", "Main Search Page" } },
            { "NewsSearch", new[]{ "NewsSearch", "News Search Page" } },
            { "EventsSearch", new[]{ "EventsSearch", "Events Search Page" } },
            { "ArtistsSearch", new[]{ "ArtistsSearch", "Artists Search Page" } },
            { "AlbumsSearch", new[]{ "AlbumsSearch", "Albums Search Page" } },
            { "GenresSearch", new[]{ "GenresSearch", "Genres Search Page" } },
            { "Post", new[]{ "Post", "" } },
            { "General", new[]{ "General", "" } },
            { "Admin", new[]{ "Admin", "Admin Page" } }
        };

        public static (
            string[] Categories, HeroViewModel Hero, AsideViewModel Aside,
            SearchViewModel Searcher, AdminPackage Admin)
            GetBody(string refinedInput) =>
            (
            GetCategories(refinedInput),
            GetHero(refinedInput), GetAside(refinedInput),
            GetSearcher(refinedInput), GetAdmin(refinedInput)
            );


        private static class Validator
        {
            public static class Validations
            {
                public static readonly Predicate<string> isGeneral = (input) => input.Equals("General");
                public static readonly Predicate<string> isNew = (input) => input.Contains("New");
                public static readonly Predicate<string> isEvent = (input) => input.Contains("Event");
                public static readonly Predicate<string> isArtist = (input) => input.Contains("Artist");
                public static readonly Predicate<string> isAlbum = (input) => input.Contains("Album");
                public static readonly Predicate<string> isGenre = (input) => input.Contains("Genre");
                public static readonly Predicate<int> isZero = (number) => number.Equals(0);
                public static readonly Predicate<string> isOverall = (asideTitle) => asideTitle.StartsWith("Overall");
                public static Predicate<string> endsWithS => (action) => action.EndsWith('s');
            }
        }


        public static class ControllerFunctionsIdentifier
        {
            public static string GetPageKind(string controllerInput) => _pageInfo[controllerInput][0];
            public static string GetPageTitle(string controllerInput) => _pageInfo[controllerInput][1];
            public static string RefineControllerInput(string controllerInput)
            {
                string refinedInput = Validator.Validations.isNew(controllerInput) ? "New" :
                    Validator.Validations.isEvent(controllerInput) ? "Event" :
                    Validator.Validations.isArtist(controllerInput) ? "Artist" :
                    Validator.Validations.isAlbum(controllerInput) ? "Album" :
                    Validator.Validations.isGenre(controllerInput) ? "Genre" : "General";
                return refinedInput;
            }
        }


        private static string[] GetCategories(string input) => Validator.Validations.isGeneral(input) ? _categories : new[] { input };
        private static HeroViewModel GetHero(string input)
        {
            List<string> imgSources = new();
            List<string> imgAlt = new();
            List<string> titles = new();
            List<string> subs = new();

            HeroViewModel hero = _heroFuncs[input](imgSources, imgAlt, titles, subs);
            return hero;
        }
        private static SearchViewModel GetSearcher(string input) => !Validator.Validations.isGeneral(input) ?
            new(null, input, null, null, null) : new(null, null, null, null, null);
        private static AsideViewModel GetAside(string input) => !Validator.Validations.isGeneral(input) ?
            AsideFunctions.GetAsideTitle(new(input, null)) : AsideFunctions.GetAsideTitle(new(null, null));
        private static AdminPackage GetAdmin(string input) => !Validator.Validations.isGeneral(input) ?
            new(null, AdminFunctions.GetCategoryId(input)) : new(null, null);


        private static class HeroFunctions
        {
            public static HeroViewModel GetHomeHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/gargola1.jpg");
                imgAlt.Add("");
                titles.Add("Welcome to Opposites by the Vertex");
                subs.Add("The page where you can find all about METAL!!!");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetPrivacyHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/home.jpg");
                imgAlt.Add("");
                titles.Add("Our Privicy Policies");
                subs.Add("HEEEERE!!!");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetAboutHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/home.jpg");
                imgAlt.Add("");
                titles.Add("Who are we?");
                subs.Add("HEEEERE!!!");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetAccountHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/account.jpg");
                imgAlt.Add("");
                titles.Add("Metalheads! Heed Here!");
                subs.Add("Unite to the next Best Metal Page of All Times!!!");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetSearchHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("General Search");
                subs.Add("");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetNewsHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Events and Shows Search");
                subs.Add("");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetEventsHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Last and BREAKING News Search");
                subs.Add("");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetArtistsHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Artists and Bands Search");
                subs.Add("");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetAlbumsHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Albums, EP's and Discographies Search");
                subs.Add("");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetGenresHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/indexsearch.jpg");
                imgAlt.Add("");
                titles.Add("Genres and Subgenres Search");
                subs.Add("");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetPostHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("");
                imgAlt.Add("");
                titles.Add("");
                subs.Add("");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
            public static HeroViewModel GetAdminHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/gargola2.jpg");
                imgAlt.Add("");
                titles.Add("Administrator Page");
                subs.Add("Make some CRUDs operations here.");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
        }


        public static class SearchFunctions
        {
            public static SearchViewModel FillSearcher(string search, string action, List<PostViewModel> avariableList, int currentPage)
            {
                List<PostViewModel> searchList = new();
                searchList = Validator.Validations.isZero(search.Length) || search.Length.Equals(1) ?
                    avariableList.Where( p => p.Title.ToLower().Contains(search)).ToList() :
                    avariableList.Where( p => p.Title.ToLower().Contains(search) ||
                    p.Title.ToLower().Contains(search.Remove(search.Length / 2)) ||
                    p.Title.ToLower().Contains(search.Substring(search.Length / 2 - 1))
                    ).ToList();
                SearchViewModel childToFeed = Validator.Validations.endsWithS(action) ?
                    new(search, action.Remove(action.Length - 1), searchList, GetPaginationData(searchList.Count), currentPage) :
                    new(search, action, searchList, GetPaginationData(searchList.Count), currentPage);
                var fedChild = childToFeed;
                return fedChild;
            }
            private static List<int> GetPaginationData(int totalPosts)
            {
                List<int> paginationData = new();
                totalPosts += !Validator.Validations.isZero(totalPosts) ? 0 : 1;
                int divider = 10;
                int totalPages = totalPosts / divider;
                var rest = totalPosts % divider;
                totalPages += Validator.Validations.isZero(rest) ? 0 : 1;

                paginationData.Add(totalPosts); paginationData.Add(totalPages); paginationData.Add(rest);
                return paginationData;
            }
        }

        private static class AsideFunctions
        {
            public static AsideViewModel GetAsideTitle(AsideViewModel childToFeed)
            {
                childToFeed.AsideTitle = Validator.Validations.isOverall(childToFeed.AsideTitle) ? childToFeed.AsideTitle :
                    AsideViewModel.AsideTitles.FirstOrDefault(title => title.Contains(childToFeed.SearchData.Action)) ??
                    "";   // in this particular case i could use a front-end variable data as a back-end one
                var fedChild = childToFeed;
                return fedChild;
            }
        }

        private static class AdminFunctions
        {
            public static int GetCategoryId(string input)
            {
                int categoryId = 0;
                categoryId = Validator.Validations.isNew(input) ? 1 :
                  Validator.Validations.isZero(categoryId) ? Validator.Validations.isEvent(input) ? 2 : 0 :
                  Validator.Validations.isZero(categoryId) ? Validator.Validations.isArtist(input) ? 3 : 0 :
                  Validator.Validations.isZero(categoryId) ? Validator.Validations.isAlbum(input) ? 4 : 0 :
                  Validator.Validations.isZero(categoryId) ? Validator.Validations.isGenre(input) ? 5 : 0 :
                  0;

                return categoryId;
            }
        }
    }
}
