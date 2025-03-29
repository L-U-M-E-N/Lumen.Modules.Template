using Lumen.Modules.Template.Common.Models;

using Microsoft.EntityFrameworkCore;

namespace Lumen.Modules.Template.Data {
    public class TemplateContext : DbContext {
        public const string SCHEMA_NAME = "Template";

        public TemplateContext(DbContextOptions<TemplateContext> options) : base(options) {
        }

        public DbSet<TemplatePointInTime> Template { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema(SCHEMA_NAME);

            var TemplateModelBuilder = modelBuilder.Entity<TemplatePointInTime>();
            TemplateModelBuilder.Property(x => x.Time)
                .HasColumnType("timestamp with time zone");

            TemplateModelBuilder.Property(x => x.AmountVideos)
                .HasColumnType("integer");

            TemplateModelBuilder.Property(x => x.SecondsDuration)
                .HasColumnType("integer");

            TemplateModelBuilder.HasKey(x => x.Time);
        }
    }
}
