using Microsoft.EntityFrameworkCore;
using SimpleApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Daftarkan service
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Daftarkan database (SQLite, filenya bernama app.db)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Bikin database + tabel otomatis kalau belum ada
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Swagger UI buat coba-coba API dari browser
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();