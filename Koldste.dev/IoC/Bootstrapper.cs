namespace koldste.dev.IoC;

public static class Bootstrapper
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        //var assembly = typeof(Bootstrapper).Assembly;

        //services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly))
        //        .AddScoped<IPostChatRequestService, ChatResponseService>()
        //        .AddScoped<IChatRequestService, ChatRequestService>()

        //        .Configure<ChatRequestParameters>(config.GetSection("OpenAi:chatRequestParameters"))
        //        .AddSingleton<ChatRequestParameters>(provider => provider.GetRequiredService<IOptions<ChatRequestParameters>>().Value)

        //        .Configure<TokenizerData>(config.GetSection("OpenAi:TokenizerData"))
        //        .AddSingleton<TokenizerData>(provider => provider.GetRequiredService<IOptions<TokenizerData>>().Value);

        return services;
    }
}
