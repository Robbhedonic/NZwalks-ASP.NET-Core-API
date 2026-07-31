using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZwalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDifficultiesAndRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2c6e41b0-8b7d-4fdf-8dfb-8a4c5ee3d102"), "Medium" },
                    { new Guid("6e9d5ab1-e4a1-4a7d-8f0a-74a2bfa6c101"), "Easy" },
                    { new Guid("f3a7c868-2d66-45a0-a6c7-26c8be20a103"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0d0f1a74-d457-4f55-9c5c-4c0ee28c9105"), "WGN", "Wellington", "https://images.unsplash.com/photo-1470770841072-f978cf4d019e" },
                    { new Guid("8c1fbea1-8b9d-43e9-8a0f-b8d7411c9104"), "BOP", "Bay of Plenty", "https://images.unsplash.com/photo-1516298773066-c48f8e9bd92b" },
                    { new Guid("a6f7b710-81b1-47fc-8665-9c715fbf9103"), "WKO", "Waikato", "https://images.unsplash.com/photo-1472396961693-142e6e269027" },
                    { new Guid("b23d4f8c-785a-4f19-a6f5-915ea2bc9106"), "CAN", "Canterbury", "https://images.unsplash.com/photo-1441974231531-c6227db76b6e" },
                    { new Guid("e0e19e8d-9ca6-4e64-93d8-4aafa1bf9101"), "AKL", "Auckland", "https://images.unsplash.com/photo-1507699622108-4be3abd695ad" },
                    { new Guid("f9da6c03-ad3e-4b53-af7e-4ae0c7d59102"), "NTL", "Northland", "https://images.unsplash.com/photo-1469474968028-56623f02e42e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2c6e41b0-8b7d-4fdf-8dfb-8a4c5ee3d102"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6e9d5ab1-e4a1-4a7d-8f0a-74a2bfa6c101"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f3a7c868-2d66-45a0-a6c7-26c8be20a103"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0d0f1a74-d457-4f55-9c5c-4c0ee28c9105"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8c1fbea1-8b9d-43e9-8a0f-b8d7411c9104"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a6f7b710-81b1-47fc-8665-9c715fbf9103"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b23d4f8c-785a-4f19-a6f5-915ea2bc9106"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e0e19e8d-9ca6-4e64-93d8-4aafa1bf9101"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f9da6c03-ad3e-4b53-af7e-4ae0c7d59102"));
        }
    }
}
