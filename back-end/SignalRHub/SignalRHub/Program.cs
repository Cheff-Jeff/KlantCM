using SignalRHub.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44357/",
                                              "https://localhost:44357/signalr",
                                              "http://localhost:54621/",
                                              "https://localhost:44334/",
                                              "https://localhost:44357",
                                              "http://127.0.0.1:5173/");
                      });
});

var app = builder.Build();


app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:44357/",
                                              "https://localhost:44357/signalr",
                                              "http://localhost:54621/",
                                              "https://localhost:44334/",
                                                  "https://localhost:44357", "http://127.0.0.1:5173/"
                                                  )
        .AllowAnyHeader()
        .WithMethods("GET", "POST")
        .AllowCredentials();
});

app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapHub<Chathub>("/signalr");
app.Run();
