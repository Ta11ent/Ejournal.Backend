var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEnewsData(builder.Configuration);
builder.Services.AddScoped<IFileHandler, FileHandler>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddAutoMapper(
    config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(INewsDbContext).Assembly));
    }
);
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var path = builder.Configuration["FilesPath"];

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.RoutePrefix = string.Empty;
        config.SwaggerEndpoint("swagger/v1/swagger.json", "Enews API");
    });
}

app.MapGet("/news/{Id}", async (Guid Id, INewsRepository repos) =>
    await repos.GetNewsAsync(Id) is NewsDetails newsDetails
    ? Results.Ok(new Response<NewsDetails>(newsDetails))
    : Results.NotFound()).WithName("GetById");

app.MapGet("/news", async (IMapper mapper, [AsParameters] GetNewsListDto newsData, INewsRepository repos) => 
{
    var param = mapper.Map<GetNewsLookup>(newsData);
    var response = await repos.GetNewsListAsync(param);
    return Results.Ok(new PageResponse<List<NewsLookup>>(response, param));
});
    
app.MapPost("/news", async (IMapper mapper, [AsParameters] CreateNewsDto newsData, INewsRepository repos) =>
{
    var data = mapper.Map<CreateNews>(newsData);
    data.Path = path!;
    var id = await repos.CreateNewsAsync(data);
    await repos.SaveAsync();
    return Results.CreatedAtRoute("GetById", new {id});
}).AddEndpointFilter<ValidationFilter<CreateNewsDto>>();

app.MapPut("/news/{Id}", 
    async (IMapper mapper, Guid Id, [AsParameters] UpdateNewsDto newsData, INewsRepository repos) =>
{
    var data = mapper.Map<UpdateNews>(newsData);
    data.NewsId = Id;
    var success = await repos.UpdateNewsAsync(data);
    if(!success) return Results.NotFound();
    await repos.SaveAsync();
    return Results.NoContent();
}).AddEndpointFilter<ValidationFilter<UpdateNewsDto>>();

app.MapPut("/news/{Id}/file/{fileId}",
    async (Guid Id, Guid fileId, [AsParameters] UpdateNewsFileDto newsFileData, INewsRepository repos) =>
{
    var success = await repos.UpdateNewsFileAsync(new UpdateNewsFile
    {
        NewsId = Id,
        FileId = fileId,
        File = newsFileData.File,
        Path = path!
    });
    if (!success) return Results.NotFound();
    await repos.SaveAsync();
    return Results.NoContent();
}).AddEndpointFilter<ValidationFilter<UpdateNewsFileDto>>();

app.MapDelete("/news/{Id}", async (Guid Id, INewsRepository repos) =>
{
    var success = await repos.DeleteAsync(Id);
    if (!success)
        return Results.NotFound();
    await repos.SaveAsync();
    return Results.NoContent();
    
});

app.UseHttpsRedirection();

app.Run();
