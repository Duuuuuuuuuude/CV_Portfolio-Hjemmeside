using koldste.dev.Models.ViewModels.SearchResults;
using Microsoft.AspNetCore.Mvc;

namespace koldste.dev.Controllers;

// /
[Route("")]
public class SearchController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        var SearchParameters = TemporaryRepositoryClass.GetSearchParameters();
        var searchResultViewModel = new SearchResultsViewModel() { SearchParameters = SearchParameters };

        return View(searchResultViewModel);
    }
}
