using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTrackAPI.Migrations
{
    /// <inheritdoc />
    public partial class outrosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Alunos_AlunoId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercicio_Treino_TreinoId",
                table: "Exercicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Treino_Alunos_AlunoId",
                table: "Treino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treino",
                table: "Treino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercicio",
                table: "Exercicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacao",
                table: "Avaliacao");

            migrationBuilder.RenameTable(
                name: "Treino",
                newName: "Treinos");

            migrationBuilder.RenameTable(
                name: "Exercicio",
                newName: "Exercicios");

            migrationBuilder.RenameTable(
                name: "Avaliacao",
                newName: "Avaliacoes");

            migrationBuilder.RenameIndex(
                name: "IX_Treino_AlunoId",
                table: "Treinos",
                newName: "IX_Treinos_AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercicio_TreinoId",
                table: "Exercicios",
                newName: "IX_Exercicios_TreinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_AlunoId",
                table: "Avaliacoes",
                newName: "IX_Avaliacoes_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treinos",
                table: "Treinos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercicios",
                table: "Exercicios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SessoesTreino",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    TreinoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessoesTreino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessoesTreino_Treinos_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExecucoesExercicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Repeticoes = table.Column<int>(type: "INTEGER", nullable: true),
                    Peso = table.Column<double>(type: "REAL", nullable: true),
                    SessaoTreinoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExercicioId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecucoesExercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecucoesExercicio_Exercicios_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExecucoesExercicio_SessoesTreino_SessaoTreinoId",
                        column: x => x.SessaoTreinoId,
                        principalTable: "SessoesTreino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExecucoesExercicio_ExercicioId",
                table: "ExecucoesExercicio",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecucoesExercicio_SessaoTreinoId",
                table: "ExecucoesExercicio",
                column: "SessaoTreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_SessoesTreino_TreinoId",
                table: "SessoesTreino",
                column: "TreinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Alunos_AlunoId",
                table: "Avaliacoes",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios",
                column: "TreinoId",
                principalTable: "Treinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treinos_Alunos_AlunoId",
                table: "Treinos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Alunos_AlunoId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercicios_Treinos_TreinoId",
                table: "Exercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Treinos_Alunos_AlunoId",
                table: "Treinos");

            migrationBuilder.DropTable(
                name: "ExecucoesExercicio");

            migrationBuilder.DropTable(
                name: "SessoesTreino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treinos",
                table: "Treinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercicios",
                table: "Exercicios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacoes",
                table: "Avaliacoes");

            migrationBuilder.RenameTable(
                name: "Treinos",
                newName: "Treino");

            migrationBuilder.RenameTable(
                name: "Exercicios",
                newName: "Exercicio");

            migrationBuilder.RenameTable(
                name: "Avaliacoes",
                newName: "Avaliacao");

            migrationBuilder.RenameIndex(
                name: "IX_Treinos_AlunoId",
                table: "Treino",
                newName: "IX_Treino_AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercicios_TreinoId",
                table: "Exercicio",
                newName: "IX_Exercicio_TreinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacoes_AlunoId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_AlunoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treino",
                table: "Treino",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercicio",
                table: "Exercicio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacao",
                table: "Avaliacao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Alunos_AlunoId",
                table: "Avaliacao",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicio_Treino_TreinoId",
                table: "Exercicio",
                column: "TreinoId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treino_Alunos_AlunoId",
                table: "Treino",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
