using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class moreHouses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "/houses/house-1.svg");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "/houses/house-2.svg");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Photo",
                value: "/houses/house-3.svg");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Photo",
                value: "/houses/house-4.svg");

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Photo",
                value: "/houses/house-5.svg");

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "Country", "Description", "Photo", "Price" },
                values: new object[,]
                {
                    { 101, "Via dei Tigli 8, Lugano", "Switzerland", "A bright lakeside villa with a terraced garden, a covered loggia and views across the water. Three bedrooms, a study and a private mooring a short walk away.", "/houses/house-6.svg", 780000 },
                    { 102, "Strandweg 14, Zandvoort", "The Netherlands", "A white coastal house two minutes from the beach, with a sun deck on the top floor, an open kitchen and a storage room for bikes and boards.", "/houses/house-7.svg", 545000 },
                    { 103, "Rue des Alpes 3, Zermatt", "Switzerland", "A timber-clad mountain cabin with a stone fireplace, a ski room and a south-facing balcony. Sleeps eight and is rented out in winter.", "/houses/house-8.svg", 1250000 },
                    { 104, "Calle del Sol 27, Valencia", "Spain", "A renovated terracotta townhouse with a courtyard, original tile floors and a roof terrace. Close to the old town and the metro.", "/houses/house-9.svg", 365000 },
                    { 105, "Königsallee 90, Düsseldorf", "Germany", "A modern four-bedroom house with floor-to-ceiling glazing, a heated double garage and a quiet garden on a tree-lined street.", "/houses/house-10.svg", 890000 }
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "Amount", "Bidder", "HouseId" },
                values: new object[,]
                {
                    { 101, 760000, "Elena Rossi", 101 },
                    { 102, 530000, "Daan de Vries", 102 },
                    { 103, 1200000, "Anna Keller", 103 },
                    { 104, 350000, "Carlos Mena", 104 },
                    { 105, 870000, "Jonas Weber", 105 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Bids",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Photo",
                value: null);
        }
    }
}
