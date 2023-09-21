using BlogPessoal.Services;
using BlogPessoal.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<RenderizadorImagens>();
builder.Services.AddScoped<ConversorHtml>();
builder.Services.AddScoped<GoogleAuthenticator>();
builder.Services.AddScoped<GoogleDriveService>();
builder.Services.AddScoped<GoogleSheetsService>();


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
