var builder = WebApplication.CreateBuilder(args);

if (args.Length > 0)
    FoudVestorPlatformEnvironment.SetEnvironment(args[0]);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtFVPlatform:Issuer"],
        ValidAudience = builder.Configuration["JwtFVPlatform:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtFVPlatform:Secret"]!))
    };
});

builder.Services.DataConfigureServices();
builder.Services.CommonConfigureServices();
builder.Services.PlatformConfigureServices();

builder.Services.AddAuthorization();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddDbContext<FoudVestorContext>();

builder.Services.AddSwaggerGen();

#if DEBUG

#endif

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();