﻿using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.Services;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Services.Searcher
{
    public static class StaticSearcher
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
            { "General", HeroFunctions.GetHomeHero },
            { "Admin", HeroFunctions.GetAdminHero },
            { "New", HeroFunctions.GetNewsHero },
            { "Event", HeroFunctions.GetEventsHero },
            { "Artist", HeroFunctions.GetArtistsHero },
            { "Album", HeroFunctions.GetAlbumsHero },
            { "Genre", HeroFunctions.GetGenresHero },
        };

        public static (string[] Categories, HeroViewModel Hero, AsideViewModel Aside, SearchViewModel Searcher, AdminPackage Admin)
            Body(string refinedInput) =>
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


        private static string[] GetCategories(string input) => Validator.Validations.isGeneral(input) ? categories : new[] { input };
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
            new(null, input, null, null) : new(null, null, null, null);
        private static AsideViewModel GetAside(string input) => !Validator.Validations.isGeneral(input) ?
            AsideFunctions.GetAsideTitle(new(input, null)) : AsideFunctions.GetAsideTitle(new(null, null));
        private static AdminPackage GetAdmin(string input) => !Validator.Validations.isGeneral(input) ?
            new(null, AdminFunctions.GetCategoryId(input)) : new(null, null);


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


        public static class SearchFunctions
        {
            public static SearchViewModel FillSearcher(string search, string action, List<PostViewModel> avariableList)
            {
                List<PostViewModel> searchList = new();
                searchList = Validator.Validations.isZero(search.Length) ? searchList : avariableList.Where(
                    p => p.Title.ToLower() == search ||
                    p.Title.ToLower() == search.Remove(search.Length / 2) ||
                    p.Title.ToLower() == search.Substring((search.Length / 2) - 1)
                    ).ToList();
                SearchViewModel childToFeed = Validator.Validations.endsWithS(action) ?
                    new(search, action.Remove(action.Length-1), searchList, GetPaginationData(searchList.Count)) :
                    new(search, action, searchList, GetPaginationData(searchList.Count));
                var fedChild = childToFeed;
                return fedChild;
            }
            private static List<int> GetPaginationData(int totalPosts)
            {
                List<int> paginationData = new();
                totalPosts += !Validator.Validations.isZero(totalPosts) ? 0 : 1;
                int divider = 10;
                int totalPages = totalPosts / divider;
                var rest = totalPages % divider;
                rest += Validator.Validations.isZero(rest) ? 0 : 1;

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
                  Validator.Validations.isZero(categoryId) ? (Validator.Validations.isEvent(input) ? 2 : 0) :
                  Validator.Validations.isZero(categoryId) ? (Validator.Validations.isArtist(input) ? 3 : 0) :
                  Validator.Validations.isZero(categoryId) ? (Validator.Validations.isAlbum(input) ? 4 : 0) :
                  Validator.Validations.isZero(categoryId) ? (Validator.Validations.isGenre(input) ? 5 : 0) :
                  0;

                return categoryId;
            }
        }
    }
}
