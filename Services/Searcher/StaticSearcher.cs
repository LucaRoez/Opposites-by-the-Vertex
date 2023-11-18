using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.Services;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.Searcher.Searcher;

namespace Opuestos_por_el_Vertice.Services.Searcher
{
    public class StaticSearcher
    {
        public static readonly string[] categories = new[] { "New", "Event", "Artist", "Album", "Genre" };
        private static readonly Dictionary<string, Func<List<string>, List<string>, List<string>, List<string>, HeroViewModel>>
            _heroFuncs = new()
        {
            { "Home", HeroFunctions.GetHomeHero },
            { "Privacy", HeroFunctions.GetPrivacyHero },
            { "About", HeroFunctions.GetAboutHero },
            { "IndexSearch", HeroFunctions.GetSearchHero },
            { "NewsSearch", HeroFunctions.GetNewsHero },
            { "EventsSearch", HeroFunctions.GetEventsHero },
            { "ArtistsSearch", HeroFunctions.GetArtistsHero },
            { "AlbumsSearch", HeroFunctions.GetAlbumsHero },
            { "GenresSearch", HeroFunctions.GetGenresHero },
            { "Post", HeroFunctions.GetPostHero },
            { "Admin", HeroFunctions.GetAdminHero }
        };

        public static (string[] Categories, HeroViewModel Hero, AsideViewModel Aside, SearchViewModel Searcher, AdminPackage Admin)
            Main(string controllerInput) =>
            (
            GetCategories(controllerInput),
            GetHero(controllerInput), GetAside(controllerInput),
            GetSearcher(controllerInput), GetAdmin(controllerInput)
            );


        public static SearchViewModel FillSearcher(string search, string action, List<PostViewModel> avariableList)
        {
            List<PostViewModel> searchList = avariableList.Where(
                p => p.Title.ToLower() == search ||
                p.Title.ToLower() == search.Remove(search.Length / 2) ||
                p.Title.ToLower() == search.Substring((search.Length / 2) - 1)
                ).ToList();
            SearchViewModel childToFeed = new(search, action, searchList, GetPaginationData(searchList.Count));
            var fedChild = childToFeed;
            return fedChild;
        }

        private static List<int> GetPaginationData(int totalPosts)
        {
            List<int> paginationData = new();
            totalPosts += !Validator.isZero(totalPosts) ? 0 : 1;
            int divider = 10;
            int totalPages = totalPosts / divider;
            var rest = totalPages % divider;
            rest += Validator.isZero(rest) ? 0 : 1;

            paginationData.Add(totalPosts); paginationData.Add(totalPages); paginationData.Add(rest);
            return paginationData;
        }


        private static class Validator
        {
            public static readonly Predicate<string> gotOneCategory = (input) => input.Equals("Post") || input.Equals("Admin") ||
                input.Contains("Search") && !input.StartsWith("Index");
            public static readonly Predicate<string> isNew = (input) => input.Equals("New");
            public static readonly Predicate<string> isEvent = (input) => input.Equals("Event");
            public static readonly Predicate<string> isArtist = (input) => input.Equals("Artist");
            public static readonly Predicate<string> isAlbum = (input) => input.Equals("Album");
            public static readonly Predicate<string> isGenre = (input) => input.Equals("Genre");
            public static readonly Predicate<int> isZero = (number) => number.Equals(0);
            public static readonly Predicate<AsideViewModel> isOverall = (childToFeed) => childToFeed.AsideTitle.StartsWith("Overall");
        }


        private static string[] GetCategories(string firstInput) => !Validator.gotOneCategory(firstInput) ? new[] { firstInput } : categories;
        private static HeroViewModel GetHero(string remainedInput)
        {
            List<string> imgSources = new();
            List<string> imgAlt = new();
            List<string> titles = new();
            List<string> subs = new();

            HeroViewModel hero = _heroFuncs[remainedInput](imgSources, imgAlt, titles, subs);
            return hero;
        }
        private static SearchViewModel GetSearcher(string refinedInput) => (Validator.isNew(refinedInput) || Validator.isEvent(refinedInput) ||
            Validator.isArtist(refinedInput) || Validator.isAlbum(refinedInput) || Validator.isGenre(refinedInput)) ?
            new(null, refinedInput, null, null) : new(null, null, null, null);
        private static AsideViewModel GetAside(string refinedInput) => (Validator.isNew(refinedInput) || Validator.isEvent(refinedInput) ||
            Validator.isArtist(refinedInput) || Validator.isAlbum(refinedInput) || Validator.isGenre(refinedInput)) ?
            AsideFunctions.GetAsideTitle(new(refinedInput, null)) : AsideFunctions.GetAsideTitle(new(null, null));
        private static AdminPackage GetAdmin(string refinedInput) => (Validator.isNew(refinedInput) || Validator.isEvent(refinedInput) ||
            Validator.isArtist(refinedInput) || Validator.isAlbum(refinedInput) || Validator.isGenre(refinedInput)) ?
            new(null, AdminFunctions.GetCategoryId(refinedInput)) : new(null, null);


        private static class HeroFunctions
        {
            public static HeroViewModel GetHomeHero(List<string> imgSources, List<string> imgAlt, List<string> titles, List<string> subs)
            {
                imgSources.Add("/img/testing/home.jpg");
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
                imgSources.Add("/img/testing/admin.jpg");
                imgAlt.Add("");
                titles.Add("Administrator Page");
                subs.Add("Make some CRUDs operations here.");

                HeroViewModel hero = new(1, imgSources, imgAlt, titles, subs);
                return hero;
            }
        }

        private static class AsideFunctions
        {
            public static AsideViewModel GetAsideTitle(AsideViewModel childToFeed)
            {
                childToFeed.AsideTitle = Validator.isOverall(childToFeed) ?
                    childToFeed.AsideTitle : AsideViewModel.AsideTitles.Where(title => title.Contains(childToFeed.SearchData.Action))
                    .ToString().Replace("[", "").Replace("]", "").Trim();   // in this particular case i could use a front-end variable data as a back-end one
                var fedChild = childToFeed;
                return fedChild;
            }
        }

        private static class AdminFunctions
        {
            public static int GetCategoryId(string input)
            {
                int categoryId = 0;
                categoryId = Validator.isNew(input) ? 1 :
                  Validator.isZero(categoryId) ? (Validator.isEvent(input) ? 2 : 0) :
                  Validator.isZero(categoryId) ? (Validator.isArtist(input) ? 3 : 0) :
                  Validator.isZero(categoryId) ? (Validator.isAlbum(input) ? 4 : 0) :
                  Validator.isZero(categoryId) ? (Validator.isGenre(input) ? 5 : 0) :
                  0;

                return categoryId;
            }
        }
    }
}
