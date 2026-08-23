using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G_NET_5_EF04.Migrations
{
    /// <inheritdoc />
    public partial class BranchManagerRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_BranchCode",
                table: "Managers",
                column: "BranchCode",
                unique: true,
                filter: "[BranchCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Branches_BranchCode",
                table: "Managers",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchCode",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_BranchCode",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "Managers");
        }
    }
}
