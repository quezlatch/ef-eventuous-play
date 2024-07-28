using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace EsPlaytime.Migrations;

public static class EventuousOperationExtensions
{
    public static OperationBuilder<EventuousOperation> Eventuous(
    this MigrationBuilder migrationBuilder,
    string? schema = null)
    {
        var operation = new EventuousOperation { Schema = schema };
        migrationBuilder.Operations.Add(operation);

        return new OperationBuilder<EventuousOperation>(operation);
    }
}