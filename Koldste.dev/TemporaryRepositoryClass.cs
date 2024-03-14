using koldste.dev.Models.ViewModels.SearchResults;
using static koldste.dev.Models.ViewModels.SearchResults.AboutDTO;
using static koldste.dev.Models.ViewModels.SearchResults.AboutDTO.AttributeDTO;

namespace koldste.dev;

// TODO: Midlertidlig model generator. Skal erstattes med data fra en database.
public static class TemporaryRepositoryClass
{
    public static SortedList<int, OnlinePresenceDTO> GetSearchResultModels() => new SortedList<int, OnlinePresenceDTO>()
        {
            {0, new OnlinePresenceDTO()
            {
                Guid = new Guid(),
                SearchResult = new SearchResultDTO(Guid: new Guid(),
                                                   SiteImageRelativePath_32_32: "/images/LinkedIn_Logo_small.png",
                                                   Cite: "https://dk.linkedin.com › martin-koldste",
                                                   Heading: "Martin Koldste – Professionshøjskolen UCN",
                                                   ResultText: "Martin Koldste | Aspirerende <b>backend</b> softwareudvikler | Jobsøgende | Datamatiker AP | Erfaring med .NET, C#, Java og SQL"),



                SiteName = "LinkedIn",
                Image_56x56 = "/images/LinkedIn_Logo.png",
                Url = "https://www.linkedin.com/in/martin-koldste",
                Type = SocialType.SocialMedia,
                Rank = 0,
            }
            },

            {1, new OnlinePresenceDTO()
            {
                Guid = new Guid(),
                SearchResult = new SearchResultDTO(Guid: new Guid(),
                                                      SiteImageRelativePath_32_32: "/images/GitHub_Logo_small.png",
                                                      Cite: "https://github.com › martin-koldste",
                                                      Heading: "Martin-Koldste/Google-Portfolio-Hjemmeside",
                                                      ResultText: "Search code, repositories, users, issues, pull requests... · Provide feedback · Saved searches Duuuuuuuuuude/Google-Portfolio-Hjemmeside."),
                 SiteName = "GitHub",
                 Image_56x56 = "",
                 Url = "https://github.com/Duuuuuuuuuude/CV-Portfolio-Hjemmeside",
                 Type =  SocialType.Portfolio,
                 Rank =  1
            }

             },

            {2, new OnlinePresenceDTO()
            {
                Guid = new Guid(),
                SearchResult = new SearchResultDTO(Guid: new Guid(),
                                                   SiteImageRelativePath_32_32: "/images/GitHub_Logo_small.png",
                                                   Cite: "https://github.com › martin-koldste",
                                                   Heading: "Martin Koldste's GitHub Profile",
                                                   ResultText: "Duuuuuuuuuude has 29 repositories available. Follow their code on GitHub."),
                SiteName = "GitHub",
                Image_56x56 = "/images/GitHub_Logo.png",
                Url = "https://github.com/Duuuuuuuuuude",
                Type = SocialType.SocialMedia,
                Rank = 2
            }
            }
        };

    public static SortedList<int, QuestionAndAnswerDTO> GetQuestionModels()
    {
        return new SortedList<int, QuestionAndAnswerDTO>()
        {
            {0, new QuestionAndAnswerDTO(Guid: new Guid(),
                                         Question: "Hvem er Martin Koldste?",
                                         Answer: "<b>Martin Koldste er en dansk backendudvikler.</b>",
                                         Rank: 0) },
            {1, new QuestionAndAnswerDTO(Guid: new Guid(),
                                         Question: "Hvor er Martin Koldste uddannet?",
                                         Answer: "<b>Martin Koldste er uddannet på professionshøjskolen UCN</b>, hvor han i Januar 2024 bestod med et flot karaktergennemsnit på 10,47.",
                                         Rank: 1) }
        };
    }

    public static SearchQueryParametersDTO GetSearchParameters() =>
        new(Guid: new Guid(),
            QueryStringAll: "\"Backend\" * \"Udvikler\" som er dygtig, flittig, nysgerrig og en teamplayer AND (\"webudvikler+udvikler\" OR \"software+udvikler\")",
            QueryStringResume: "(intitle:CV) Martin Koldste's CV",
            QueryStringAbout: "define:Martin Koldste");

    public static SortedList<int, RelatedSearchDTO> GetRelatedSearches() => new()
        {
            {0, new(Guid: new Guid(), Text: "Chris Hemsworth", Rank: 0)},
            {1, new(Guid: new Guid(), Text: "Martin Fowler", Rank: 1) },
            {2, new(Guid : new Guid(), Text: "Software udvikler", Rank: 2) },
            {3, new(Guid: new Guid(), Text: "Matthew Mcconaughey", Rank: 3) },
            {4, new(Guid : new Guid(), Text: "Bedste udviklere i Danmark?", Rank: 4) },
            {5, new(Guid: new Guid(), Text: "Backend udvikler", Rank: 5) }
        };

    public static AboutDTO GetAboutModels() => new AboutDTO()
    {
        Guid = new Guid(),
        JobTitle = "Aspirerende Backend Udvikler",

        Images = new SortedList<int, AboutImageDTO>()
            {
                { 0,
                    new AboutImageDTO(Guid : new Guid(), "test", Position: 0) }
            },

        AboutText = "Martin Koldste er en aspirerende Software udvikler, der søger efter nye muligheder for benytte sin viden indenfor programmering/systemydvikling. Martin Koldste er en dygtig udvikler (backend), der blev færdiguddannet datamatiker (AP) i år 2024, og er lige nu igang med at finde et arbejde som softwareudvikler.",

        AboutAttributtes = new SortedList<int, AttributeDTO>()
            {
                {1, new BirthdateAttributeDTO() {
                    Guid = new Guid(),
                    Name = "Født",
                    Value = new DateTime(1992, 11, 08),
                    Birthplace = "Aalborg, Danmark",
                    Rank = 1
                } },

                {2, new AttributeDTO() {
                    Guid = new Guid(),
                    Name = "Højde",
                    Value = "1,75 m (5' 9\")",
                    Rank = 2
                } },

                {3, new AttributeDTO() {
                    Guid = new Guid(),
                    Name = "Uddannelsessted",
                    Value = "Professionshøjskole UCN (2021-2024)",
                    Rank = 3
                } },

                {4, new AttributeDTO() {
                    Guid = new Guid(),
                    Name = "Grad",
                    Value = "AP, Datamatiker",
                    Rank = 4
                } },

                {5, new AttributeDTO() {
                    Guid = new Guid(),
                    Name = "Sprog",
                    Value = "Dansk, Engelsk",
                    Rank = 5
                } },

                {6, new AttributeDTO() {
                    Guid = new Guid(),
                    Name = "Interesser",
                    Value = "IT Nørd, 3D Print, Fitness, Guitar",
                    Rank = 6
                } },

                {7, new AttributeDTO() {
                    Guid = new Guid(),
                    Name = "Skostørrelse",
                    Value = "42 (EU)",
                    Rank = 7
                } },
            },

        OnlinePresences = new SortedList<int, OnlinePresenceDTO>()
        {
            {0, new OnlinePresenceDTO() { Guid = new Guid(),
            SearchResult = null,
            SiteName = "LinkedIn",
            Url = "https://www.linkedin.com/in/martin-koldste",
            Type = SocialType.SocialMedia,
            Rank = 0 } },

            {1, new OnlinePresenceDTO() { Guid = new Guid(),
            SearchResult = null,
            SiteName = "GitHub",
            Url = "https://github.com/Duuuuuuuuuude",
            Type = SocialType.SocialMedia,
            Rank = 1 } }
        },

        Skills = new List<SkillDTO>
        {
            new SkillDTO(Guid: new Guid(), Text: ".NET", Type: SkillType.Professional, Rank: 0),
            new SkillDTO(Guid: new Guid(), Text: "Detaljeorienteret", Type: SkillType.Personal, Rank: 0),

            new SkillDTO(Guid: new Guid(), Text:"MVC", Type: SkillType.Professional, Rank: 1),
            new SkillDTO(Guid: new Guid(), Text: "Flittig", Type: SkillType.Personal, Rank: 1),

            new SkillDTO(Guid: new Guid(), Text: "MSSQL", Type: SkillType.Professional, Rank: 2),
            new SkillDTO(Guid: new Guid(), Text: "Punktlig", Type: SkillType.Personal, Rank: 2),

            new SkillDTO(Guid: new Guid(), Text: "Razor", Type: SkillType.Professional, Rank: 3),
            new SkillDTO(Guid: new Guid(), Text: "Selvstændig", Type: SkillType.Personal, Rank: 3),

            new SkillDTO(Guid: new Guid(), Text: "Webudvikling", Type: SkillType.Professional, Rank: 4),
            new SkillDTO(Guid: new Guid(), Text: "Samarbejdsvillig", Type: SkillType.Personal, Rank: 4),

            new SkillDTO(Guid: new Guid(), Text: "DevOps", Type: SkillType.Professional, Rank: 5),
            new SkillDTO(Guid: new Guid(), Text: "Kvalitetsorienteret", Type: SkillType.Personal, Rank: 5),

            new SkillDTO(Guid: new Guid(), Text: "Java", Type: SkillType.Professional, Rank: 6),
            new SkillDTO(Guid: new Guid(), Text: "Engageret", Type: SkillType.Personal, Rank: 6),

            new SkillDTO(Guid: new Guid(), Text: "ASP.NET", Type: SkillType.Professional, Rank: 7),
            new SkillDTO(Guid: new Guid(), Text: "Vedholdende", SkillType.Personal, Rank: 7),

            new SkillDTO(Guid: new Guid(), Text: "ADO.NET", Type: SkillType.Professional, Rank: 8),
            new SkillDTO(Guid: new Guid(), Text: "Nysgerrig", Type: SkillType.Personal, Rank: 8),

            new SkillDTO(Guid: new Guid(), Text: "RESTful API", Type: SkillType.Professional, Rank: 9),
            new SkillDTO(Guid: new Guid(), Text: "Struktureret", Type: SkillType.Personal, Rank: 9),


            new SkillDTO(Guid: new Guid(), Text: "CLEAN Architecture", Type: SkillType.Professional, Rank: 10),

            new SkillDTO(Guid: new Guid(), Text: "CQRS", Type: SkillType.Professional, Rank: 11),

            new SkillDTO(Guid: new Guid(), Text: "MACH", Type: SkillType.Professional, Rank: 12),

            new SkillDTO(Guid: new Guid(), Text: "Mediator", Type: SkillType.Professional, Rank: 13),

            new SkillDTO(Guid: new Guid(), Text: "Scrum", Type: SkillType.Professional, Rank: 14),

            new SkillDTO(Guid: new Guid(), Text: "Microsoft Identity Platform", Type: SkillType.Professional, Rank: 15),

            new SkillDTO(Guid: new Guid(), Text: "Microsoft Graph", Type: SkillType.Professional, Rank: 16),

            new SkillDTO(Guid: new Guid(), Text: "Python", Type: SkillType.Professional, Rank: 17),

            new SkillDTO(Guid: new Guid(), Text: "GIT", Type: SkillType.Professional, Rank: 18),

            new SkillDTO(Guid: new Guid(), Text: "XP", Type: SkillType.Professional, Rank: 19),

            new SkillDTO(Guid: new Guid(), Text: "Waterfall Projektstyring", Type: SkillType.Professional, Rank: 20),

            new SkillDTO(Guid: new Guid(), Text: "Backend Udvikling", Type: SkillType.Professional, Rank: 21),

            new SkillDTO(Guid: new Guid(), Text: "Agil Projektstyring", Type: SkillType.Professional, Rank: 22),

            new SkillDTO(Guid: new Guid(), Text: "JavaScript", Type: SkillType.Professional, Rank: 23),

            new SkillDTO(Guid: new Guid(), Text: "Azure", Type: SkillType.Professional, Rank: 24),
        }
    };
}