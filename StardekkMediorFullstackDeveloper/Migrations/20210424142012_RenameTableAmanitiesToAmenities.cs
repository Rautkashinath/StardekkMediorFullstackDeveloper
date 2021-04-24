using Microsoft.EntityFrameworkCore.Migrations;

namespace StardekkMediorFullstackDeveloper.Migrations
{
    public partial class RenameTableAmanitiesToAmenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE TABLE Amenities_temp AS SELECT *
                                                    FROM Amanities;
              
                      DROP TABLE Amanities;
              
                      CREATE TABLE Amenities (
                          Id INTEGER NOT NULL
                                 CONSTRAINT PK_Amenities PRIMARY KEY AUTOINCREMENT,
                          Name TEXT NULL,
                          RoomTypeId INTEGER NULL,
                          FOREIGN KEY (RoomTypeId)
                            REFERENCES RoomTypes(Id)
                      );
              
                      INSERT INTO Amenities 
                      (
                          Id,
                          Name,
                          RoomTypeId
                      )
                      SELECT Id,
                             Name,
                             RoomTypeId
                      FROM Amenities_temp;
              
                      DROP TABLE Amenities_temp;"
                    );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_RoomTypes_RoomTypeId",
                table: "Amenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities");

            migrationBuilder.RenameTable(
                name: "Amenities",
                newName: "Amanities");

            migrationBuilder.RenameIndex(
                name: "IX_Amenities_RoomTypeId",
                table: "Amanities",
                newName: "IX_Amanities_RoomTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amanities",
                table: "Amanities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Amanities_RoomTypes_RoomTypeId",
                table: "Amanities",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
