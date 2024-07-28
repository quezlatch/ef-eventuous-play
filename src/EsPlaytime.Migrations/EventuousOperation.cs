using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EsPlaytime.Migrations;

public class EventuousOperation : MigrationOperation
{
    public string? Schema { get; set; } = "eventuous";
}
