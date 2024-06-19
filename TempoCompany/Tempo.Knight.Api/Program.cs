using AutoMapper;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using Tempo.Knight.Api.Config;
using Tempo.Knight.Infra;
using Tempo.Knight.Setup.Middleware;

try
{
    var builder = WebApplication.CreateBuilder(args);



    builder.Services.AddEntityFramework(builder.Configuration);

    builder.Services.AddSevicesTempo();

    //CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost8080", policy =>
        {
            policy
                .WithOrigins("http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();  // Se você precisar suportar cookies, autorização baseada em sessão, etc.
        });
    });


    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Tempo Knights Challenge",
            Description = "Development in .NET 8  Web API Knights control/manager of register of hereos"
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    builder.Services.AddAutoMapper(typeof(Program));
    var mapperConfig = new MappingProfile().mapperConfig;
    builder.Services.AddSingleton<IMapper>(new Mapper(mapperConfig));

    builder.AddSerilogApi(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddExceptionHandler<ErrorHandlingMiddleware>();
    builder.Services.AddProblemDetails();
    builder.Services.AddMvc(options =>
    {
        options.Filters.Add(typeof(ReformatValidationProblemAttribute));
    });

    var app = builder.Build();
    app.UseCors("AllowLocalhost8080");

  
    app.UseSwagger();
    app.UseExceptionHandler();
    app.UseStaticFiles();//Primordial para exibir configuração de layout no swagger.
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Tempo1 Knights V1.0");
        opt.DocumentTitle = "Tempo Knight";
        opt.InjectStylesheet("/swagger-ui/custom.css");
        //Primordial propriedade do arquivo css esteja com content e copy always.
    });

    if (app.Environment.IsDevelopment()){}

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}