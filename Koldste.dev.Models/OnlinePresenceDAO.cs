namespace Koldste.dev.Models;

public class OnlinePresenceDAO
{
    public required int Id { get; init; }
    public required Guid Guid { get; init; }
    public SearchResultDAO? SearchResult { get; init; }
    public required string SiteName { get; init; }
    public string? Image_56x56 { get; init; }
    public required string Url { get; init; }
    //public string? Description { get; init; }
    public required SocialType Type { get; init; }
    public required int Rank { get; init; }

    public enum SocialType
    {
        Portfolio,
        SocialMedia
    }

}

public record SearchResultDAO(int Id,
                              Guid Guid,
                              string SiteImageRelativePath_32_32,
                              string Cite,
                              string Heading,
                              string ResultText);