using Lumen.Modules.Sdk;
using Lumen.Modules.Template.Data;

using Microsoft.EntityFrameworkCore;

namespace Lumen.Modules.Template.Module {
    public class TemplateModule(IEnumerable<ConfigEntry> configEntries, ILogger<LumenModuleBase> logger, IServiceProvider provider) : LumenModuleBase(configEntries, logger, provider) {
        public override Task InitAsync(LumenModuleRunsOnFlag currentEnv) {
            // Nothing to do
            return Task.CompletedTask;
        }

        public override async Task RunAsync(LumenModuleRunsOnFlag currentEnv, DateTime date) {
            try {
                logger.LogTrace($"[{nameof(TemplateModule)}] Running tasks ...");
                throw new NotImplementedException();
            } catch (Exception ex) {
                logger.LogError(ex, $"[{nameof(TemplateModule)}] Error when running tasks.");
            }
        }

        public override bool ShouldRunNow(LumenModuleRunsOnFlag currentEnv, DateTime date) {
            return currentEnv switch {
                LumenModuleRunsOnFlag.UI => date.Second == 0 && date.Minute == 42,
                LumenModuleRunsOnFlag.API => date.Second == 0 && date.Minute % 5 == 0,
                _ => false,
            };
        }

        public override Task ShutdownAsync() {
            // Nothing to do
            return Task.CompletedTask;
        }

        public static new void SetupServices(LumenModuleRunsOnFlag currentEnv, IServiceCollection serviceCollection, string? postgresConnectionString) {
            if (currentEnv == LumenModuleRunsOnFlag.API) {
                serviceCollection.AddDbContext<TemplateContext>(o => o.UseNpgsql(postgresConnectionString, x => x.MigrationsHistoryTable("__EFMigrationsHistory", TemplateContext.SCHEMA_NAME)));
            }
        }

        public override Type GetDatabaseContextType() {
            return typeof(TemplateContext);
        }
    }
}
