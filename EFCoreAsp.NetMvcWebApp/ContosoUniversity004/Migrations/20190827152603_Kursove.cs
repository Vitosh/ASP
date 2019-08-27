using Microsoft.EntityFrameworkCore.Migrations;

namespace ContosoUniversity.Migrations
{
    public partial class Kursove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptiones_Cursos_CourseId",
                table: "Inscriptiones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos");

            migrationBuilder.RenameTable(
                name: "Cursos",
                newName: "Kursove");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kursove",
                table: "Kursove",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptiones_Kursove_CourseId",
                table: "Inscriptiones",
                column: "CourseId",
                principalTable: "Kursove",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptiones_Kursove_CourseId",
                table: "Inscriptiones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kursove",
                table: "Kursove");

            migrationBuilder.RenameTable(
                name: "Kursove",
                newName: "Cursos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cursos",
                table: "Cursos",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptiones_Cursos_CourseId",
                table: "Inscriptiones",
                column: "CourseId",
                principalTable: "Cursos",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
