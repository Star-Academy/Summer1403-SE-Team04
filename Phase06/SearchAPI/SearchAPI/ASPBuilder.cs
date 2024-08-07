using Microsoft.OpenApi.Models;

namespace SearchAPI;

public class AspBuilder(WebApplicationBuilder builder)
{
    public void Build()
    {
        builder.Services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "SearchAPIApi", Version = "v1" })
        );
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SearchAPI"));
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseDeveloperExceptionPage();
        app.UseRouting();
        app.UseAuthorization();
        app.Run();
    }
}