using TrueRealtor.API.Customs;

namespace TrueRealtor.API.Extensions;

public static class WebApplicationExtension
{
    public static void SetupApp(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
