using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class AddMentorToAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "Alunos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mentores",
                columns: table => new
                {
                    MentorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimeiroNome = table.Column<string>(type: "text", nullable: false),
                    SegundoNome = table.Column<string>(type: "text", nullable: true),
                    Sobrenome = table.Column<string>(type: "text", nullable: false),
                    NumeroTelefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentores", x => x.MentorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_MentorId",
                table: "Alunos",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Mentores_MentorId",
                table: "Alunos",
                column: "MentorId",
                principalTable: "Mentores",
                principalColumn: "MentorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Mentores_MentorId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "Mentores");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_MentorId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Alunos");
        }
    }
}
