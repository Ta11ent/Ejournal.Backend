using Ejournal.AuthenticationManager.Helpers;

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
builder.Services.AddApiVersioning(options => options.ApiVersionReader = new UrlSegmentApiVersionReader());
builder.Services.AddAuthenticationManager();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var path = builder.Configuration["FilesPath"];

var app = builder.Build();

var versionSet = app.NewApiVersionSet()
    .HasApiVersion(1.0)
    .Build();

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

app.MapGet("v{version:apiVersion}/api/news/{Id}",
    async (HttpContext context, Guid Id, INewsRepository repos) =>
{
    var apiVersion = context.GetRequestedApiVersion();
    return await repos.GetNewsAsync(Id) is NewsDetails newsDetails
        ? Results.Ok(new Response<NewsDetails>(newsDetails))
        : Results.NotFound();
})
.WithName("GetById")
.WithApiVersionSet(versionSet)
.MapToApiVersion(1.0)
.RequireAuthorization(Policy.Management);

app.MapGet("v{version:apiVersion}/api/news",
    async (IMapper mapper, HttpContext context, [AsParameters] GetNewsListDto newsData, INewsRepository repos) =>
{
    var apiVersion = context.GetRequestedApiVersion();
    var param = mapper.Map<GetNewsLookup>(newsData);
    var response = await repos.GetNewsListAsync(param);
    return Results.Ok(new PageResponse<List<NewsLookup>>(response, param));
})
.WithApiVersionSet(versionSet)
.MapToApiVersion(1.0)
.RequireAuthorization(Policy.Management);

app.MapPost("v{version:apiVersion}/api/news", 
    async (IMapper mapper, HttpContext context, CreateNewsDto newsData, INewsRepository repos) =>
{
    var apiVersion = context.GetRequestedApiVersion();
    var data = mapper.Map<CreateNews>(newsData);
    data.Path = path!;
    var id = await repos.CreateNewsAsync(data);
    await repos.SaveAsync();
    return Results.CreatedAtRoute("GetById", new {id});
})
.AddEndpointFilter<ValidationFilter<CreateNewsDto>>()
.WithApiVersionSet(versionSet)
.MapToApiVersion(1.0)
.RequireAuthorization(Policy.Management);

app.MapPut("v{version:apiVersion}/api/news/{Id}", 
    async (IMapper mapper, HttpContext context, Guid Id, UpdateNewsDto newsData, INewsRepository repos) =>
{
    var apiVersion = context.GetRequestedApiVersion();
    var data = mapper.Map<UpdateNews>(newsData);
    data.NewsId = Id;
    var success = await repos.UpdateNewsAsync(data);
    if(!success) return Results.NotFound();
    await repos.SaveAsync();
    return Results.NoContent();
})
.AddEndpointFilter<ValidationFilter<UpdateNewsDto>>()
.WithApiVersionSet(versionSet)
.MapToApiVersion(1.0)
.RequireAuthorization(Policy.Management);

app.MapPut("v{version:apiVersion}/api/news/{Id}/file/{fileId}",
    async (HttpContext context, Guid Id, Guid fileId, UpdateNewsFileDto newsFileData, INewsRepository repos) =>
{
    var apiVersion = context.GetRequestedApiVersion();
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
})
.AddEndpointFilter<ValidationFilter<UpdateNewsFileDto>>()
.WithApiVersionSet(versionSet)
.MapToApiVersion(1.0)
.RequireAuthorization(Policy.Management);

app.MapDelete("v{version:apiVersion}/api/news/{Id}", 
    async (HttpContext context, Guid Id, INewsRepository repos) =>
{
    var apiVersion = context.GetRequestedApiVersion();
    var success = await repos.DeleteAsync(Id);
    if (!success) return Results.NotFound();
    await repos.SaveAsync();
    return Results.NoContent();
})
.WithApiVersionSet(versionSet)
.MapToApiVersion(1.0)
.RequireAuthorization(Policy.Management);

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.Run();
