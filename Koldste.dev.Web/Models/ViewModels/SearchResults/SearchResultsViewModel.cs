using AgeCalculator;

namespace Koldste.dev.Web.Models.ViewModels.SearchResults;

public class SearchResultsViewModel
{
    public SortedList<int, OnlinePresenceDTO> SearchResults { get; init; } = [];
    public SortedList<int, QuestionAndAnswerDTO> PeopleAlsoAsk { get; init; } = [];
    public required SearchQueryParametersDTO SearchParameters { get; init; }
    public SortedList<int, RelatedSearchDTO> RelatedSearches { get; init; } = [];
    public AboutDTO? About { get; init; }
}

/// <param name="Rank">In what order they show up in the search results.</param>
public record QuestionAndAnswerDTO(Guid Guid,
                                     string Question,
                                     string Answer,
                                     int Rank);

public record SearchQueryParametersDTO(Guid Guid,
                                         string QueryStringAll,
                                         string QueryStringResume,
                                         string QueryStringAbout,
                                         string QueryStringPortfolio);

public class OnlinePresenceDTO
{
    public required Guid Guid { get; init; }
    public SearchResultDTO? SearchResult { get; init; }
    public required string SiteName { get; init; }
    public string Image_56x56 { get; init; } = string.Empty;
    public required string Url { get; init; }
    public required SocialType Type { get; init; }
    public required int Rank { get; init; }
}

/// <param name="Rank">In what order they show up in the search results. </param>
public record SearchResultDTO(Guid Guid,
                                   string SiteImageRelativePath_32_32,
                                   string Cite,
                                   string Heading,
                                   string ResultText);

public enum SocialType
{
    Portfolio,
    SocialMedia
}

/// <param name="Text"></param>
/// <param name="Rank">How the <see cref="RelatedSearchDTO"/>es are positioned in the pattern: 1  2
///                                                                                            3  4
///                                                                                            5  6 </param>
public record RelatedSearchDTO(Guid Guid, string Text, int Rank);

public class AboutDTO
{
    public required Guid Guid { get; init; }
    public required string JobTitle { get; init; }
    public SortedList<int, AboutImageDTO> Images { get; init; } = [];
    public required string AboutText { get; init; }
    public required SortedList<int, AttributeDTO>? AboutAttributtes { get; init; } = [];
    public required SortedList<int, OnlinePresenceDTO> OnlinePresences { get; init; }

    private List<SkillDTO> _skills = new();
    /// <summary>
    /// Ordered by rank.
    /// </summary>
    public List<SkillDTO> Skills { get => [.. _skills?.OrderBy(skill => skill.Rank)]; init => _skills = value; }


    /// <param name="Position"></param>
    public record AboutImageDTO(Guid Guid, string ImageRelativePath, int Position);

    public class AttributeDTO
    {
        public required Guid Guid { get; init; }
        public required string Name { get; init; }
        public object Value { get; init; }
        public required int Rank { get; init; }

        public class BirthdateAttributeDTO : AttributeDTO
        {
            public required new DateTime Value { get; init; }
            public required string Birthplace { get; init; }
            public int Age => new Age(Value, DateTime.Now).Years;
        }
    }

}

public record SkillDTO(Guid Guid, string Text, SkillType Type, int Rank);

public enum SkillType
{
    Professional,
    Personal
}