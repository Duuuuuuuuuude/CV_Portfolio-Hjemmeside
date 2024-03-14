namespace Koldste.dev.Models;

/// <param name="Rank">How the <see cref="RelatedSearchDTO"/>es are positioned in the pattern: 1  2
///                                                                                            3  4
///                                                                                            5  6
public record RelatedSearchDAO(int Id, Guid Guid, string Text, int Rank);