using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.DataAccess.Migrations
{
    public partial class updated_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageLists_ProjectDetails_ProjectDetailID",
                table: "ImageLists");

            migrationBuilder.DropIndex(
                name: "IX_ImageLists_ProjectDetailID",
                table: "ImageLists");

            migrationBuilder.RenameColumn(
                name: "ProjectDetailID",
                table: "ImageLists",
                newName: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ImageLists",
                newName: "ProjectDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLists_ProjectDetailID",
                table: "ImageLists",
                column: "ProjectDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageLists_ProjectDetails_ProjectDetailID",
                table: "ImageLists",
                column: "ProjectDetailID",
                principalTable: "ProjectDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
