using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandyShop.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Treats",
                columns: new[] { "TreatId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Made With Rich Chocolate, Silky Caramel, Chewy Nougat & Packed With Crunchy Nutty Goodness.", "Snickers" },
                    { 2, "American candy by The Hershey Company consisting of a peanut butter cup encased in chocolate", "Reese's" },
                    { 3, "Made of three layers of wafer separated and covered by an outer layer of chocolate", "KitKat" },
                    { 4, "Small, fruit gum candies, similar to a jelly baby in some English-speaking countries", "Haribo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Treats",
                keyColumn: "TreatId",
                keyValue: 4);
        }
    }
}
