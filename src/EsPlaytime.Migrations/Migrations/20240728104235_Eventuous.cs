﻿using Eventuous.SqlServer;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsPlaytime.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Eventuous : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Eventuous("dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
