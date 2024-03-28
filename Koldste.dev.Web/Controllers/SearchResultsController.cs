using Koldste.dev.Web.Models;
using Koldste.dev.Web.Models.ViewModels.SearchResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Koldste.dev.Web.Controllers;

// /Search
[Route("Search")]
public class SearchResultsController() : Controller
{
    // GET: /Search?q=Martin Koldste's CV
    [HttpGet]
    public ActionResult Index([FromQuery] string q)
    {
        var SearchParameters = TemporaryRepositoryClass.GetSearchParameters();

        if (string.Equals(q, SearchParameters.QueryStringResume, StringComparison.OrdinalIgnoreCase))
        {
            ViewData["SearchQueryParameter"] = SearchParameters.QueryStringResume;
            return View("Resume", new SearchResultsViewModel() { SearchParameters = SearchParameters, About = TemporaryRepositoryClass.GetAboutModels() }); // TODO: Midlertidlig løsning, indtil "SearchResults/Index" view er mere dynamisk.
        }

        if (string.Equals(q, SearchParameters.QueryStringAbout, StringComparison.OrdinalIgnoreCase))
        {
            ViewData["SearchQueryParameter"] = SearchParameters.QueryStringAbout;
            return View("About", new SearchResultsViewModel() { SearchParameters = SearchParameters, About = TemporaryRepositoryClass.GetAboutModels() }); // TODO: Midlertidlig løsning, indtil "SearchResults/Index" view er mere dynamisk.
        }

        if (string.Equals(q, SearchParameters.QueryStringPortfolio, StringComparison.OrdinalIgnoreCase))
        {
            ViewData["SearchQueryParameter"] = SearchParameters.QueryStringPortfolio;
            return View("Portfolio", new SearchResultsViewModel() { SearchParameters = SearchParameters, About = TemporaryRepositoryClass.GetAboutModels() }); // TODO: Midlertidlig løsning, indtil "SearchResults/Index" view er mere dynamisk.
        }

        ViewData["SearchQueryParameter"] = SearchParameters.QueryStringAll;
        return base.View(new SearchResultsViewModel() { SearchResults = TemporaryRepositoryClass.GetSearchResultModels(), PeopleAlsoAsk = TemporaryRepositoryClass.GetQuestionModels(), SearchParameters = TemporaryRepositoryClass.GetSearchParameters(), RelatedSearches = TemporaryRepositoryClass.GetRelatedSearches(), About = TemporaryRepositoryClass.GetAboutModels() });
    }

    [HttpGet("[action]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()

    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}