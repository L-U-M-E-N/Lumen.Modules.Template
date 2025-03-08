using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lumen.Modules.Template.Data {
    public class TemplateDbContextFactory : IDesignTimeDbContextFactory<TemplateContext> {
        public TemplateContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<TemplateContext>();
            optionsBuilder.UseNpgsql();

            return new TemplateContext(optionsBuilder.Options);
        }
    }
}
