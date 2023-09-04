using ITsena_back;
using ITsena_back.Data;
using ITsena_back.Repositories;
using ITsena_back.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCompression(options => {options.EnableForHttps = true;});

//Services DI
builder.Services.AddScoped<JwtService>();
builder.Services.AddTransient<IEmailSender,EmailSender>();
builder.Services.AddScoped<ICacheService, CacheService>();

//features DI
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();

//DBContext
builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCompression();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
