using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dcContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            dcContext.Database.Migrate();

            return app;
        }
    }
}
