public void ConfigureServices(IServiceCollection services)
{
    // Add your service registrations here
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IYourService, YourService>();
    // Add other service registrations...

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ... other configurations

    app.UseCors("AllowAll");

    // ... other app configurations
});
    });
}