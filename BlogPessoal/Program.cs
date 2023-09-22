using BlogPessoal.Interfaces;
using BlogPessoal.Services.Google;
using BlogPessoal.Services.Html;
using BlogPessoal.Services.Imagem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IRenderizadorImagem, RenderizadorImagens>();
builder.Services.AddScoped<IConversorHtml, ConversorHtml>();
builder.Services.AddScoped<IAutenticavel, GoogleAuthenticator>();
builder.Services.AddScoped<IDriveService,GoogleDriveService>();
builder.Services.AddScoped<ISheetService,GoogleSheetsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
