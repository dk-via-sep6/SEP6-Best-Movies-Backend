using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AuthorUsernameToComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorUsername",
                table: "MovieRatings");

            migrationBuilder.AddColumn<string>(
                name: "AuthorUsername",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorUsername",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "AuthorUsername",
                table: "MovieRatings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
