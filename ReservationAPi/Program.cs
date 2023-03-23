using Microsoft.EntityFrameworkCore;
using ReservationAPi.Data;
using ReservationAPi.Repository;
using ReservationAPi.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string cs = builder.Configuration.GetConnectionString("cnStr");
builder.Services.AddDbContext<AppliactionDbContext>(options => options.UseSqlServer(cs));
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
