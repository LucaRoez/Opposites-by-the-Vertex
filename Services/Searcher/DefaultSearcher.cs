using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.DataTranfer;

namespace Opuestos_por_el_Vertice.Services.Searcher
{
    public class DefaultSearcher : ISearcher
    {
        private readonly IRepository _repository;
        public DefaultSearcher(IRepository repository)
        {
            _repository = repository;
        }

        // database comunication behavior
        public List<PostViewModel> GetViewModelList(string[] schemas, int iterations)
        {
            List<BasePost> Posts = new();
            for (int i = 0; i < iterations; i++)
            {
                if (i == 0) { Posts = _repository.DetailAll(schemas[i]); } else { Posts.AddRange(_repository.DetailAll(schemas[i])); }
            }

            return DataConverter.GetAllViewModels(Posts);
        }
        public async Task<PostViewModel> GetViewModel(int id, string postCategory) => DataConverter.GetViewModel(await _repository.DetailOne(postCategory, id));

        // search mechanism
        public List<PostViewModel> GetSearch(string search, string category)
        {
            List<BasePost> finalSearch = new();
            if (search == "" || search == null)
            {
                if (category == "Index")
                {
                    finalSearch = GlobalSearch(finalSearch, "");
                }
                else { finalSearch = GetSearchList(category, finalSearch, ""); }
            }
            else
            {
                if (category == "Index")
                {
                    finalSearch = GlobalSearch(finalSearch, search);
                }
                else { finalSearch = GetSearchList(category, finalSearch, search); }
            }

            return DataConverter.GetAllViewModels(finalSearch);
        }
        private List<BasePost> GlobalSearch(List<BasePost> finalSearch, string search)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 4: finalSearch = GetSearchList("Genre", finalSearch, search); break;

                    case 3: finalSearch = GetSearchList("Album", finalSearch, search); break;

                    case 2: finalSearch = GetSearchList("Artist", finalSearch, search); break;

                    case 1: finalSearch = GetSearchList("Event", finalSearch, search); break;

                    default: finalSearch = GetSearchList("New", finalSearch, search); break;
                }
            }

            return finalSearch;
        }
        private List<BasePost> GetSearchList(string memory, List<BasePost> List, string search)
        {
            if (search != "")
            {
                search = search.Trim().ToLower();
                string searchStart = ""; string searchEnd = "";
                for (int i = 0; i < search.Length / 2; i++) { searchStart += search[i]; }
                for (int i = search.Length / 2; i < search.Length; i++) { searchEnd += search[i]; }

                if (searchStart == "" || searchEnd == "") { List.AddRange(_repository.DetailAll(memory).Where(p => p.Title.ToLower().Contains(search)).ToList()); }
                else
                {
                    List.AddRange(_repository.DetailAll(memory).Where(p => p.Title.ToLower().Contains(search) || p.Title.ToLower().Contains(searchStart) || p.Title.ToLower().Contains(searchEnd)).ToList());
                }
            }
            else { List.AddRange(_repository.DetailAll(memory)); }

            return List;
        }

        // pagination loads
        public List<int> GetPaginationData(int totalPosts)
        {
            List<int> paginationData = new();
            if (totalPosts == 0) { totalPosts++; }
            var divider = 10;
            var totalPages = totalPosts / divider;
            var rest = totalPosts % divider;
            if (rest > 0) { totalPages++; }

            paginationData.Add(totalPosts); paginationData.Add(totalPages); paginationData.Add(rest);
            return paginationData;
        }

        // asides info search
        public AsideViewModel GetAsideSearch(List<PostViewModel> pageList, string pageKind, PostViewModel model, SearchViewModel search)
        {
            AsideViewModel finalAside = new();
            finalAside.AsidesList = SelectPostList(pageKind, finalAside.AsidesList, pageList);

            finalAside.AsideTitles.Add("Artist or Bands More Popular");
            finalAside.AsideTitles.Add("Shows and Concerts More Popular");
            finalAside.AsideTitles.Add("Relevant Metal News");
            finalAside.AsideTitles.Add("Albums More Popular");
            finalAside.AsideTitles.Add("Genres or Subgenres More Popular");
            finalAside.AsideTitle = GetFinalAsideTitle(finalAside.AsideTitles, model.Category, pageKind);

            finalAside.SearchData = GetActionView(pageKind, model.Category, search);

            return finalAside;
        }
        private List<List<PostViewModel>> SelectPostList(string pageKind, List<List<PostViewModel>> asidesList, List<PostViewModel> pageList)
        {
            if (pageKind.Equals("Post") || pageKind.Contains("Search") && !pageKind.Contains("Index"))
            {
                // single post cast categorization
                if (pageList.Count > 0)
                {
                    if (pageList[0].Category.Equals("New")) { asidesList.Add(pageList.Where(p => p.Category == "New").ToList()); }
                    else if (pageList[0].Category.Equals("Event")) { asidesList.Add(pageList.Where(p => p.Category == "Event").ToList()); }
                    else if (pageList[0].Category.Equals("Genre")) { asidesList.Add(pageList.Where(p => p.Category == "Genre").ToList()); }
                    else if (pageList[0].Category == "Album") { asidesList.Add(pageList.Where(p => p.Category == "Album").ToList()); }
                    else { asidesList.Add(pageList.Where(p => p.Category == "Artist").ToList()); }     // always it prioritize Artist catalog front anothers options
                }
                else { List<PostViewModel> ghostAside = new(); asidesList.Add(ghostAside); }
            }
            else
            {
                // general multi-post cast categorization
                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 2: asidesList.Add(pageList.Where(p => p.Category == "New").ToList()); break;
                        case 1: asidesList.Add(pageList.Where(p => p.Category == "Event").ToList()); break;
                        default: asidesList.Add(pageList.Where(p => p.Category == "Artist").ToList()); break;
                    }
                }
            }

            return asidesList;
        }
        private string GetFinalAsideTitle(List<string> asideTitles, string modelCategory, string pageKind)
        {
            string asideTitle = "";
            // this is for the Post path
            if (modelCategory != "")
            {
                switch (modelCategory)
                {
                    case "Genre": asideTitle = asideTitles[4]; break;
                    case "Album": asideTitle = asideTitles[3]; break;
                    case "New": asideTitle = asideTitles[2]; break;
                    case "Event": asideTitle = asideTitles[1]; break;
                    default: asideTitle = asideTitles[0]; break;
                }
            }
            // and this for the specific Search one
            else if (pageKind.Contains("Search") && !pageKind.Contains("Index"))
            {
                switch (pageKind)
                {
                    case "GenresSearch": asideTitle = asideTitles[4]; break;
                    case "AlbumsSearch": asideTitle = asideTitles[3]; break;
                    case "NewsSearch": asideTitle = asideTitles[2]; break;
                    case "EventsSearch": asideTitle = asideTitles[1]; break;
                    default: asideTitle = asideTitles[0]; break;
                }
            }
            // finally there's no need to set the colective aside titles list because we already have it in the asideTitles list with the order
            return asideTitle;
        }
        private SearchViewModel GetActionView(string pageKind, string modelCategory, SearchViewModel search)
        {
            if (pageKind.Contains("Search") && !pageKind.Contains("Index"))
            {
                search.Action = pageKind.Replace("Search", "");
            }
            else if (pageKind == "Post") { search.Action = modelCategory + "s"; }
            else if (pageKind == "Admin") { search.Action = modelCategory; }
            else { search.Action = "Index"; }

            return search;
        }
    }
}
