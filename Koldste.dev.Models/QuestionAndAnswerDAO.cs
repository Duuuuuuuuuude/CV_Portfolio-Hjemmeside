namespace Koldste.dev.Models;

/// <param name="Rank">In what order they show up in the search results. </param>
public record QuestionAndAnswerDAO(int Id,
                                   Guid Guid,
                                   string Question,
                                   string Answer,
                                   int Rank);