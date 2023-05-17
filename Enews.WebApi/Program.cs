var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEnewsData(builder.Configuration);
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddAutoMapper(
    config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(INewsDbContext).Assembly));
    }
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<NewsDbContext>();
        DbInitializer.Initialize(context);
    }
    catch(Exception exception)
    {
        var loger = serviceProvider.GetRequiredService<ILogger<Program>>();
        loger.LogError(exception, "Ann error ocurred while app initialization");
    }
}


//app.MapGet("/", () => "Hello World!");

app.MapGet("/news", async (INewsRepository repos) =>
    Results.Ok(await repos.GetNewsListAsync()));

app.MapPost("news", async (IMapper _mapper, [FromBody] CreateNewsDto newsData, INewsRepository repos) =>
{
    var data = _mapper.Map<CreateNews>(newsData);
    await repos.CreateNewsAsync(data);
    await repos.SaveAsync();

});


app.UseHttpsRedirection();

app.Run();
