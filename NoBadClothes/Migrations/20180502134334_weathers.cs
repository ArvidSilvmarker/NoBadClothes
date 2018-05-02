using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NoBadClothes.Migrations
{
    public partial class weathers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrecipationCategory = table.Column<int>(nullable: false),
                    PrecipationMean = table.Column<double>(nullable: false),
                    StationId = table.Column<int>(nullable: true),
                    Temperature = table.Column<double>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    WeatherSymbol = table.Column<int>(nullable: false),
                    WindDirection = table.Column<int>(nullable: false),
                    WindGust = table.Column<double>(nullable: false),
                    WindSpeed = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weathers_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_StationId",
                table: "Weathers",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
