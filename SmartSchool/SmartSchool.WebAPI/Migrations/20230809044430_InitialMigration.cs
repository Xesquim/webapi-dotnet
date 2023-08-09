using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registro = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataConclusao", "DataMatricula", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1301), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1312), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1317), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1322), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1326), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1332), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1336), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataMatricula", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1114), "Lauro", 1, "Oliveira", null },
                    { 2, true, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1135), "Roberto", 2, "Soares", null },
                    { 3, true, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1137), "Ronaldo", 3, "Marconi", null },
                    { 4, true, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1138), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1139), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, null, 1, "Matemática", null, 1 },
                    { 2, null, 3, "Matemática", null, 1 },
                    { 3, null, 3, "Física", null, 2 },
                    { 4, null, 1, "Português", null, 3 },
                    { 5, null, 1, "Inglês", null, 4 },
                    { 6, null, 2, "Inglês", null, 4 },
                    { 7, null, 3, "Inglês", null, 4 },
                    { 8, null, 1, "Programação", null, 5 },
                    { 9, null, 2, "Programação", null, 5 },
                    { 10, null, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataConclusao", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1363), null },
                    { 1, 4, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1366), null },
                    { 1, 5, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1367), null },
                    { 2, 1, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1368), null },
                    { 2, 2, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1369), null },
                    { 2, 5, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1371), null },
                    { 3, 1, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1371), null },
                    { 3, 2, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1372), null },
                    { 3, 3, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1373), null },
                    { 4, 1, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1374), null },
                    { 4, 4, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1375), null },
                    { 4, 5, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1376), null },
                    { 5, 4, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1377), null },
                    { 5, 5, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1378), null },
                    { 6, 1, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1378), null },
                    { 6, 2, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1379), null },
                    { 6, 3, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1380), null },
                    { 6, 4, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1382), null },
                    { 7, 1, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1383), null },
                    { 7, 2, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1384), null },
                    { 7, 3, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1384), null },
                    { 7, 4, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1385), null },
                    { 7, 5, null, new DateTime(2023, 8, 9, 1, 44, 30, 200, DateTimeKind.Local).AddTicks(1386), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
