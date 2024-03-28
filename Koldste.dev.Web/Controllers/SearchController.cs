using Koldste.dev.Web.Models.ViewModels.SearchResults;
using Microsoft.AspNetCore.Mvc;

namespace Koldste.dev.Web.Controllers;

// /
[Route("")]
public class SearchController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var SearchParameters = TemporaryRepositoryClass.GetSearchParameters();
        var searchResultViewModel = new SearchResultsViewModel() { SearchParameters = SearchParameters };

        return View(searchResultViewModel);
    }
}
