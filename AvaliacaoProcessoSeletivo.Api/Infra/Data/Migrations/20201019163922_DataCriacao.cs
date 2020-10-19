using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaliacaoProcessoSeletivo.Api.Infra.Data.Migrations
{
    public partial class DataCriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Conta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Conta");


        }
    }
}
