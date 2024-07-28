using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Update;
using Eventuous.SqlServer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EsPlaytime.Migrations;

// from https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/operations
public class EsMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
{
    public EsMigrationsSqlGenerator(
        MigrationsSqlGeneratorDependencies dependencies,
        ICommandBatchPreparer commandBatchPreparer)
        : base(dependencies, commandBatchPreparer)
    {
    }

    protected override void Generate(
        MigrationOperation operation,
        IModel? model,
        MigrationCommandListBuilder builder)
    {
        if (operation is EventuousOperation eventuousOperation)
        {
            Generate(eventuousOperation);
        }
        else
        {
            base.Generate(operation, model, builder);
        }
    }

    private void Generate(EventuousOperation operation)
    {
        var eventuousSchema = new Schema(operation.Schema!);
        eventuousSchema.CreateSchema(() =>
        {
            // do not use connection from database, or 'puter go splat
            var connectionString = Dependencies.CurrentContext.Context.Database.GetConnectionString();
            return new SqlConnection(connectionString);
        }).Wait();
    }
}
