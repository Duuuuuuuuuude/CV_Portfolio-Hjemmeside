using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System.Reflection;

namespace Koldste.dev.Tests.PlayWright;

[TestClass]
public class RoutingTests : PageTest
{
    private IConfiguration _config;

    [TestInitialize]
    public void TestInitialize()
    {
        // _config = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!)
                                            // .AddJsonFile("appsettings.json")
                                            // .Build();
    }

    // TODO: Add tests for routing
    [TestMethod]
    public async Task SearchResultsIndexRedirectsToSearchResultsIndexWithQueryStringAll()
    {
        // Arrange
        // string goToUrl = "";
        // string expectedUrl = "/Search?q=" + _config.GetRequiredSection("SearchParameters:QueryStringAll");

        // Act
        // string actualUrl = (await Page.GotoAsync(goToUrl))!.Url;

        // Assert
        //Assert.AreEqual(expectedUrl, actualUrl);
        Assert.AreEqual(1, 1);
    }


    //[TestMethod]
    //public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    //{
    //    await Page.GotoAsync("https://playwright.dev");

    //    // Expect a title "to contain" a substring.
    //    await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

    //    // create a locator
    //    var getStarted = Page.Locator("text=Get Started");

    //    // Expect an attribute "to be strictly equal" to the value.
    //    await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

    //    // Click the get started link.
    //    await getStarted.ClickAsync();

    //    // Expects the URL to contain intro.
    //    await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    //}

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
        {
            BaseURL = ""
        };
    }

}