using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.API.Migrations
{
    public partial class AddRoomModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    SystemConfigID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Thumbnail = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
