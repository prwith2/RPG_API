using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: true, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    PontosVida = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Defesa = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false),
                    FotoPersonagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Disputas = table.Column<int>(type: "int", nullable: false),
                    Vitorias = table.Column<int>(type: "int", nullable: false),
                    Derrotas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_ARMAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false),
                    PersonagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ARMAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 40, "Queimar" },
                    { 2, 35, "Sangramento" },
                    { 3, 30, "Envenenemento" }
                });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS",
                columns: new[] { "Id", "Classe", "Defesa", "Derrotas", "Disputas", "Forca", "FotoPersonagem", "Inteligencia", "Nome", "PontosVida", "UsuarioId", "Vitorias" },
                values: new object[,]
                {
                    { 1, 1, 23, 0, 0, 17, null, 33, "Frodo", 100, null, 0 },
                    { 2, 1, 25, 0, 0, 15, null, 30, "Sam", 100, null, 0 },
                    { 3, 3, 21, 0, 0, 18, null, 35, "Galadriel", 100, null, 0 },
                    { 4, 2, 18, 0, 0, 18, null, 37, "Gandalf", 100, null, 0 },
                    { 5, 1, 17, 0, 0, 20, null, 31, "Hobbit", 100, null, 0 },
                    { 6, 3, 13, 0, 0, 21, null, 34, "Celeborn", 100, null, 0 },
                    { 7, 2, 11, 0, 0, 25, null, 35, "Radagast", 100, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "seuEmail@example.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 27, 113, 4, 69, 236, 0, 30, 236, 167, 126, 174, 119, 105, 186, 246, 69, 59, 219, 182, 152, 40, 135, 161, 41, 155, 174, 96, 160, 252, 165, 28, 15, 101, 33, 86, 213, 194, 38, 146, 36, 48, 100, 50, 27, 225, 148, 140, 172, 79, 120, 88, 255, 211, 53, 48, 184, 75, 1, 101, 196, 227, 51, 198, 58 }, new byte[] { 38, 97, 230, 200, 150, 162, 125, 126, 254, 157, 28, 235, 66, 61, 4, 9, 82, 232, 240, 137, 222, 35, 202, 146, 18, 160, 219, 57, 132, 110, 108, 232, 4, 209, 11, 121, 139, 14, 85, 25, 228, 13, 83, 31, 112, 81, 208, 142, 56, 198, 101, 253, 157, 235, 176, 168, 28, 19, 20, 155, 25, 2, 191, 146, 252, 114, 74, 108, 155, 213, 38, 73, 168, 230, 184, 19, 108, 136, 214, 224, 191, 105, 136, 223, 97, 202, 47, 104, 10, 224, 153, 33, 3, 44, 157, 194, 169, 214, 94, 47, 174, 222, 132, 85, 190, 201, 75, 100, 206, 30, 73, 10, 249, 78, 97, 26, 183, 136, 67, 29, 79, 91, 222, 122, 208, 13, 178, 95 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.InsertData(
                table: "TB_ARMAS",
                columns: new[] { "Id", "Dano", "Nome", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 10, "A Cimitar dos Orcs", 7 },
                    { 2, 27, "Espada de Gandalf", 1 },
                    { 3, 25, "Espada de Aragorn", 3 },
                    { 4, 30, "Cajado do Gandalf", 4 },
                    { 5, 15, "Adaga", 5 },
                    { 6, 666, "Olho de Sauron", 6 },
                    { 7, 20, "Arco e Flecha elfico", 2 }
                });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 3, 6 },
                    { 2, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_UsuarioId",
                table: "TB_PERSONAGENS",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ARMAS");

            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");
        }
    }
}
