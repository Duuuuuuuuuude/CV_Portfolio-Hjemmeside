namespace Koldste.dev.Models;

public record SearchQueryParametersDAO(int Id,
                                       Guid Guid,
                                       string QueryStringAll,
                                       string QueryStringResume,
                                       string QueryStringAbout);
