namespace Koldste.dev.Models;
using AgeCalculator;

public class AboutDAO
{
    public required int Id { get; init; }
    public required Guid Guid { get; init; }
    public required string JobTitle { get; set; }
    public SortedList<int, AboutImageDAO> Images { get; init; } = [];
    public required string AboutText { get; init; }
    public required SortedList<int, AttributeDAO>? AboutAttributtes { get; init; } = [];
    public required SortedList<int, OnlinePresenceDAO> OnlinePresences { get; init; }
    public List<SkillDAO> Skills { get; init; }
}

/// <param name="Position"></param>
public record AboutImageDAO(int Id,
                            Guid Guid,
                            string ImageRelativePath,
                            int Position);

public class AttributeDAO
{
    public required int Id { get; init; }
    public required Guid Guid { get; init; }
    public required string Name { get; init; }
    public object Value { get; init; }
    public required int Rank { get; init; }

    public class BirthdateAttributeDAO : AttributeDAO
    {
        public required new DateTime Value { get; init; }
        public required string Birthplace { get; init; }
        public int Age => new Age(Value, DateTime.Now).Years;
    }
}

public record SkillDAO(int Id,
                       Guid Guid,
                       string Text,
                       SkillType Type,
                       int Rank);

public enum SkillType
{
    Professional,
    Personal
}