using SignalRHub;
using SignalRHub.Hubs;
using SignalRHub.Models;
using SignalRHub.Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
    options.StreamBufferCapacity = 10 * 1024 * 1024;
    options.MaximumReceiveMessageSize = 2147483647;
});

builder.Services.AddSingleton<IRepo<EndUser, string>, RepoEndUser>();

builder.Services.AddSingleton<IRepo<Room, int>, RepoRoom>();


builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials();
        }));

var app = builder.Build();



app.UseRouting();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapHub<Chathub>("/signalr");
app.MapControllers();

app.Run();
