using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneCatalog.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Owners_OwnerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Phones_PhoneId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_CategoryTypes_CategoryId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Owners_OwnerId",
                table: "Phones");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "4145caa1-bb58-49bc-8218-08c90d225399", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEBQLsX60x1wL9q4ETUlmam6HORk+YgrxUKdzgq+BjtVz1PmwPRW4kV2At3aeuK64vw==", null, false, "89cd7dab-5cbb-4faa-9b5b-43ad54a3ff04", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "e62a6e71-30ad-4f8a-8439-5d74c485187d", "owner@mail.com", false, false, null, "owner@mail.com", "owner@mail.com", "AQAAAAEAACcQAAAAENa66s0ZW6poeEHW3Biei6UbRBNGTBWjtn9Eh5RjQtZGhiLk83Dsvit246Iy79j+GQ==", null, false, "a06643f5-d885-45f4-bc3e-ed6b205c427b", false, "owner@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "CategoryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SmartPhone" },
                    { 2, "MobilePhone" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "0882515555", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 2, "0882616666", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "0888777444", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "CategoryId", "ImageUrl", "Model", "OwnerId", "Price" },
                values: new object[] { 1, "Iphone", 1, "https://buybest.bg/storage/public/uploads/media-manager/app-modules-shop-models-optiongroups/2252/4108/iphone-14-red-prod.png", "14", 1, 1500m });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "CategoryId", "ImageUrl", "Model", "OwnerId", "Price" },
                values: new object[] { 2, "Samsung", 1, "https://s13emagst.akamaized.net/products/64817/64816457/images/res_e68a0194a894e1d6b8e13ee37aad5d58.jpg", "Galaxy S24 Ultra", 2, 2000m });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "CategoryId", "ImageUrl", "Model", "OwnerId", "Price" },
                values: new object[] { 3, "Nokia", 2, "https://www.infinitygsm.ro/wp-content/uploads/2023/08/Nokia-150-2023-Black.jpg", "150 2023", 3, 100m });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "OwnerId", "PhoneId" },
                values: new object[] { 1, "This phone is very good for me. Its very fast and have a good camera for photo!", 3, 1 });

            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "Id", "Battery", "CameraPxl", "PhoneId", "Processor", "Ram", "Storage" },
                values: new object[,]
                {
                    { 1, "Lithium ion batteries 4000mAh", "12MP Ultra Wide", 1, "6‑Core CPU 2 performance 4 efficiency Core", "6 GB ", "256 GB" },
                    { 2, "Lithium ion batteries 5000mAh", "200.0 MP + 50.0 MP + 12.0 MP + 10.0 MP", 2, "8 Core 3.39GHz", "8 GB ", "512 GB" },
                    { 3, " 1450 mAh", "No Camera", 3, "1 Core", "512MB ", "16 GB" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Owners_OwnerId",
                table: "Comments",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Phones_PhoneId",
                table: "Comments",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_CategoryTypes_CategoryId",
                table: "Phones",
                column: "CategoryId",
                principalTable: "CategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Owners_OwnerId",
                table: "Phones",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Owners_OwnerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Phones_PhoneId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_CategoryTypes_CategoryId",
                table: "Phones");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Owners_OwnerId",
                table: "Phones");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Owners_OwnerId",
                table: "Comments",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Phones_PhoneId",
                table: "Comments",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_CategoryTypes_CategoryId",
                table: "Phones",
                column: "CategoryId",
                principalTable: "CategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Owners_OwnerId",
                table: "Phones",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
