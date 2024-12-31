using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCVForum.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyForum");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Recruiters",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Companies",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Candidates",
                newName: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Recruiters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EvaluationDate",
                table: "Evaluations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ForumId",
                table: "Evaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CandidateCompanies",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ForumId = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCompanies", x => new { x.CandidateId, x.CompanyId, x.ForumId });
                    table.ForeignKey(
                        name: "FK_CandidateCompanies_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCompanies_Forums_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forums",
                        principalColumn: "ForumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForumCompanies",
                columns: table => new
                {
                    ForumId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCompanies", x => new { x.ForumId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_ForumCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForumCompanies_Forums_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forums",
                        principalColumn: "ForumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ForumId",
                table: "Evaluations",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompanies_CompanyId",
                table: "CandidateCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompanies_ForumId",
                table: "CandidateCompanies",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumCompanies_CompanyId",
                table: "ForumCompanies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_Forums_ForumId",
                table: "Evaluations",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "ForumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluations_Forums_ForumId",
                table: "Evaluations");

            migrationBuilder.DropTable(
                name: "CandidateCompanies");

            migrationBuilder.DropTable(
                name: "ForumCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Evaluations_ForumId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Recruiters");

            migrationBuilder.DropColumn(
                name: "EvaluationDate",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "ForumId",
                table: "Evaluations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Recruiters",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Companies",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "Candidates",
                newName: "FullName");

            migrationBuilder.CreateTable(
                name: "CompanyForum",
                columns: table => new
                {
                    CompaniesCompanyId = table.Column<int>(type: "int", nullable: false),
                    ForumsForumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyForum", x => new { x.CompaniesCompanyId, x.ForumsForumId });
                    table.ForeignKey(
                        name: "FK_CompanyForum_Companies_CompaniesCompanyId",
                        column: x => x.CompaniesCompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyForum_Forums_ForumsForumId",
                        column: x => x.ForumsForumId,
                        principalTable: "Forums",
                        principalColumn: "ForumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyForum_ForumsForumId",
                table: "CompanyForum",
                column: "ForumsForumId");
        }
    }
}
