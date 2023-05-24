using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.IServices;
using Service.Services;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<SmtpClient>(serviceProvider =>
{
    string smtpServer = configuration["SmtpConfig:SmtpServer"];
    int smtpPort = Convert.ToInt32(configuration["SmtpConfig:SmtpPort"]);
    string smtpUsername = configuration["SmtpConfig:SmtpUsername"];
    string smtpPassword = configuration["SmtpConfig:SmtpPassword"];
    bool enableSsl = Convert.ToBoolean(configuration["SmtpConfig:EnableSsl"]);


    var smtpClient = new SmtpClient(smtpServer, smtpPort);
    smtpClient.EnableSsl = enableSsl;
    Console.WriteLine(smtpUsername + ":" + smtpPassword);
    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

    return smtpClient;
});

builder.Services.AddTransient<IPersona, PersonaServicio>();
builder.Services.AddTransient<IEmail, MailService>();
builder.Services.AddScoped<ILogin, LoginService>();
// Add services to the container.

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
