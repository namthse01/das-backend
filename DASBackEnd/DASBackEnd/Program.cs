using DASBackEnd.Data;
using DASBackEnd.IRepository;
using DASBackEnd.IServices;
using DASBackEnd.Models;
using DASBackEnd.Repository;
using DASBackEnd.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DasContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DAS")));

builder.Services.AddScoped<IBookingServices, BookingServices>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<ISlotServices, SlotServices>();
builder.Services.AddScoped<ISlotRepository, SlotRepository>();

builder.Services.AddScoped<IDaServices, DaServices>();
builder.Services.AddScoped<IServicesRepository, DaServicesRepository>();

builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IBookingDetailServices, BookingDetailServices>();
builder.Services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


var app = builder.Build();

app.UseCors(policy => policy.AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .SetIsOriginAllowed(origin => true));

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
