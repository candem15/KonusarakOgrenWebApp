using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemsId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { new Guid("92f6361a-04ed-4bde-a4ac-84aba9b1f7ca"), "Connondale" },
                    { new Guid("d478d6e1-64ea-4f63-a635-96f176c560cc"), "Trek" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0bfb6c1a-af0c-4a14-848f-f6912a10e2ab"), "These bikes include an electric motor which you can charge by plugging it into a regular outlet.  When you peddle, the electric motor provides an assist so that you go faster and hills are made easier.", "Electric Bike" },
                    { new Guid("60d70416-906c-4c1c-8f5e-a0183bf6cada"), "This bike is designed with excellent braking systems and shock-absorbing features that can easily handle serious bumps, rocks, dirt trails, roots and ruts.", "Mountain Bike" },
                    { new Guid("e3980339-1e2e-49b2-acd4-bc80d245e446"), "Road bikes are best identified by their drop or turned-down handlebars and skinny tires.", "Road Bike" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "City", "District", "Name", "Street" },
                values: new object[,]
                {
                    { new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), "Ankara", "Cankaya", "Hakan Bisikletman", "Sezginler Street" },
                    { new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), "Izmir", "Buca", "Eray Berberoglu", "206/5" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate" },
                values: new object[,]
                {
                    { new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), new DateTime(2022, 3, 1, 7, 22, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("db88ba95-54a5-4094-9ade-2402654b7c95"), new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), new DateTime(2021, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ddb45744-e12e-49b2-a428-718d082f88f1"), new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), new DateTime(2008, 5, 24, 3, 21, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "Color", "ModelYear", "Name", "Price", "Quantity", "Size" },
                values: new object[,]
                {
                    { new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), new Guid("d478d6e1-64ea-4f63-a635-96f176c560cc"), new Guid("60d70416-906c-4c1c-8f5e-a0183bf6cada"), "Marigold to Red Fade", 2015, "Rail 9.9 XX1 AXS", 13799.99, 100, "L" },
                    { new Guid("3a8e9167-a66a-4b19-88f7-8c6ed0821229"), new Guid("d478d6e1-64ea-4f63-a635-96f176c560cc"), new Guid("60d70416-906c-4c1c-8f5e-a0183bf6cada"), "Carbon Red", 2022, "Rail 9.8 XT", 9199.9899999999998, 200, "M" },
                    { new Guid("405e657d-68f9-4c66-8a91-b7baffb20eaf"), new Guid("d478d6e1-64ea-4f63-a635-96f176c560cc"), new Guid("0bfb6c1a-af0c-4a14-848f-f6912a10e2ab"), "Gloss Alpine Navy Smoke", 2021, "E-Caliber 9.9 XTR", 12549.99, 300, "XL" },
                    { new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47"), new Guid("92f6361a-04ed-4bde-a4ac-84aba9b1f7ca"), new Guid("e3980339-1e2e-49b2-acd4-bc80d245e446"), "Stealth Grey", 2018, "CAAD13 Disc 105", 18529.990000000002, 300, "XS" },
                    { new Guid("a3921483-a45e-4cb7-846d-7c28446bf7a6"), new Guid("92f6361a-04ed-4bde-a4ac-84aba9b1f7ca"), new Guid("e3980339-1e2e-49b2-acd4-bc80d245e446"), "Candy Red", 2020, "CAAD Optimo", 23213.0, 300, "S" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CustomerId", "ProductComment", "ProductId" },
                values: new object[,]
                {
                    { new Guid("19e3f536-a607-4f49-9cc1-b3929a1c24d2"), new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), "I got a trek mountain track steel framed bike three years ago and put a 49cc 4 stoke motor on it. I did modify the brakes and put a oil shock front fork on it and it's held up awesome, no cracks or weak spots. All my friends have had to reinforce their bikes in less time than I've had mine. I could not ask for better.. ABSOLUTELY LOVE MY TREK !!!!!!!!!", new Guid("3a8e9167-a66a-4b19-88f7-8c6ed0821229") },
                    { new Guid("3786ab8a-40dd-4013-8c62-ebe670d8a4ca"), new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), "For most of the bikes I test, I feel like they excel at either climbing or descending. However, the Cannondale Trail 6 really shines as a mellow all-rounder… it lands comfortably in the middle as a true generalist.", new Guid("a3921483-a45e-4cb7-846d-7c28446bf7a6") },
                    { new Guid("54bd18c7-3668-405a-89fe-5e97020d6b3c"), new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), "For this price, you do get hydros… It’s an SLX shifter. This works so smooth… The bike itself is really light.", new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a") },
                    { new Guid("ad76f53b-2679-4eda-88e2-98720815839e"), new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), "I purchased this bike to use as a commuter bike… to be capable enough to ride MTB trails… after putting 200mi on it in the three months that I’ve owned it, I can say with confidence that this bike fits the bill.", new Guid("405e657d-68f9-4c66-8a91-b7baffb20eaf") },
                    { new Guid("e7f4fe96-6c87-4769-ac53-bdb08867cfbe"), new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), "My order went wrong however I was extremely happy with how Will dealt with my issue and I wouldn't hesitate to place another order. ", new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a") },
                    { new Guid("eab0705f-b01b-4aaa-9afd-54a5f0d4491e"), new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), "I had a really good experience here, I ordered some parts from the online site. They were at a great price and it said 4 - 8 days for delivery which was longer than I would have liked but for the price I couldn't complain. The parts arrived the next day and were well packaged and as described! What more could you ask for!", new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a") },
                    { new Guid("f215ddb7-09eb-4a86-81c2-68a51bd59cec"), new Guid("3a6437c3-5dc9-4321-9d48-a753e90e2d5a"), "Smartform aluminium frame is one of the most comfortable here… Stand-over clearance is at a premium …seat tube is way too tall… Cannondale… if you’re a heavy rider this fork may just be too quick.", new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47") },
                    { new Guid("fbaaf426-db46-4fcb-bbff-52b3d16bcd28"), new Guid("d6b855eb-231c-4ea1-8285-2b9ccaffe275"), "The Trail 1 is a bike that seems like an excellent choice on which to gain experience… The intermediate step between a beginner’s bike and a more expensive, expert model.", new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47") }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemsId", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2eee2316-a6a7-4cbc-b716-f88197513cbf"), new Guid("ddb45744-e12e-49b2-a428-718d082f88f1"), new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47"), 6 },
                    { new Guid("5da55686-5ef1-4906-851e-b206b748f320"), new Guid("db88ba95-54a5-4094-9ade-2402654b7c95"), new Guid("405e657d-68f9-4c66-8a91-b7baffb20eaf"), 7 },
                    { new Guid("61c9ace3-9225-4559-b541-45fe7d5f73d8"), new Guid("db88ba95-54a5-4094-9ade-2402654b7c95"), new Guid("70fb6660-0bba-428d-a5a7-814eb3b3bf47"), 2 },
                    { new Guid("95c21140-b58d-44a5-8d3b-214a90e59b7d"), new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), new Guid("a3921483-a45e-4cb7-846d-7c28446bf7a6"), 5 },
                    { new Guid("be250e81-d0c2-4379-9c8a-d9f0336404ed"), new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), new Guid("3a8e9167-a66a-4b19-88f7-8c6ed0821229"), 2 },
                    { new Guid("e304535a-5e65-4ec8-80de-adeeadaf55c9"), new Guid("ddb45744-e12e-49b2-a428-718d082f88f1"), new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), 4 },
                    { new Guid("e901026d-a174-4f3f-9efd-542c2bb620c5"), new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), 3 },
                    { new Guid("ee68e4bf-ce6a-4a8a-beb6-7ca35476547a"), new Guid("ddb45744-e12e-49b2-a428-718d082f88f1"), new Guid("405e657d-68f9-4c66-8a91-b7baffb20eaf"), 1 },
                    { new Guid("ffd9e796-d416-4ab7-8ef2-9957957a5f0d"), new Guid("5e589759-dc33-4979-ab6b-5edc93a6ba29"), new Guid("3645bfdf-16e7-42a4-abdb-cc38c770eb8a"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
