using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlinePizzaOrderingSystemUpdatedAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DeliveryAddress = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StoreName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    StoreManager = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsageCount = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMenuItems", x => new { x.CustomerId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_CustomerMenuItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMenuItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    AdditionalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toppings_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDrivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    VehicleInformation = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDrivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryDrivers_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DeliveryOptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DeliveryDriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryDrivers_DeliveryDriverId",
                        column: x => x.DeliveryDriverId,
                        principalTable: "DeliveryDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DeliveryAddress", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "123 Main St", "john.smith@example.com", "John Smith" },
                    { 2, "456 Oak Ave", "jane.doe@example.com", "Jane Doe" },
                    { 3, "789 Elm St", "bob.johnson@example.com", "Bob Johnson" },
                    { 4, "321 Maple Rd", "sarah.lee@example.com", "Sarah Lee" },
                    { 5, "654 Pine Blvd", "david.kim@example.com", "David Kim" },
                    { 6, "987 Cedar Dr", "maria.hernandez@example.com", "Maria Hernandez" },
                    { 7, "246 Birch Ln", "tom.wilson@example.com", "Tom Wilson" },
                    { 8, "135 Oakwood Ave", "emily.chen@example.com", "Emily Chen" },
                    { 9, "864 Maple St", "michael.brown@example.com", "Michael Brown" },
                    { 10, "753 Pine Ave", "amy.nguyen@example.com", "Amy Nguyen" },
                    { 11, "246 Cedar Ln", "james.lee@example.com", "James Lee" },
                    { 12, "975 Oak St", "samantha.patel@example.com", "Samantha Patel" },
                    { 13, "864 Maple Rd", "william.johnson@example.com", "William Johnson" },
                    { 14, "753 Pine St", "linda.davis@example.com", "Linda Davis" },
                    { 15, "246 Cedar Ave", "chris.wilson@example.com", "Chris Wilson" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Email", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "info@location1.com", "555-1234" },
                    { 2, "456 Elm St", "info@location2.com", "555-5678" },
                    { 3, "789 Oak St", "info@location3.com", "555-2468" },
                    { 4, "321 Pine St", "info@location4.com", "555-7890" },
                    { 5, "654 Cedar St", "info@location5.com", "555-1357" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Juicy beef burger topped with melted cheese", "Cheeseburger", 9.99m },
                    { 2, "Classic pizza with tomato sauce, mozzarella cheese, and fresh basil", "Margherita Pizza", 11.99m },
                    { 3, "Fresh romaine lettuce with croutons, parmesan cheese, and Caesar dressing", "Caesar Salad", 7.99m },
                    { 4, "Pasta with bacon, eggs, cream, and parmesan cheese", "Spaghetti Carbonara", 12.99m },
                    { 5, "Crispy battered fish with French fries and tartar sauce", "Fish and Chips", 10.99m },
                    { 6, "Pasta with grilled chicken and creamy Alfredo sauce", "Chicken Alfredo", 13.99m },
                    { 7, "Fresh salmon fillet grilled to perfection with lemon butter sauce", "Grilled Salmon", 14.99m },
                    { 8, "Sliced beef with mixed vegetables in a savory sauce, served over rice", "Beef Stir Fry", 11.99m },
                    { 9, "Grilled vegetables with hummus and feta cheese, wrapped in a spinach tortilla", "Veggie Wrap", 8.99m },
                    { 10, "Slow-cooked pork ribs with BBQ sauce and coleslaw", "BBQ Ribs", 15.99m },
                    { 11, "Creamy Arborio rice with mushrooms and parmesan cheese", "Mushroom Risotto", 10.99m },
                    { 12, "Three soft tacos with seasoned beef, lettuce, cheese, and salsa", "Beef Tacos", 9.99m },
                    { 13, "Pasta with shrimp, garlic, butter, and white wine sauce", "Shrimp Scampi", 13.99m },
                    { 14, "Mixed vegetables in a spicy curry sauce, served over rice", "Vegetable Curry", 10.99m },
                    { 15, "Grilled chicken with romaine lettuce, croutons, and Caesar dressing, wrapped in a flour tortilla", "Chicken Caesar Wrap", 8.99m }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Pepperoni", 30.25m, 12.0 },
                    { 2, "Vegetarian", 20m, 10.0 },
                    { 3, "Meat Lovers", 100m, 16.0 },
                    { 4, "Supreme", 25.50m, 14.0 },
                    { 5, "Hawaiian", 30.25m, 12.0 },
                    { 6, "Margherita", 35.75m, 14.0 },
                    { 7, "BBQ Chicken", 70m, 16.0 },
                    { 8, "Buffalo Chicken", 48m, 12.0 },
                    { 9, "Sausage and Mushroom", 92m, 14.0 },
                    { 10, "Four Cheese", 59m, 12.0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "StoreManager", "StoreName" },
                values: new object[,]
                {
                    { 1, "John Doe", "ABC Grocery" },
                    { 2, "Jane Smith", "XYZ Pharmacy" },
                    { 3, "Sara Lee", "XYZ Pharmacy" },
                    { 4, "Bob Johnson", "123 Mart" },
                    { 5, "Alice Smith", "456 Pharmacy" },
                    { 6, "Mike Brown", "GHI Hardware" },
                    { 7, "Tom Wilson", "JKL Grocery" },
                    { 8, "Sara Lee", "MNO Pharmacy" },
                    { 9, "John Doe", "PQR Hardware" },
                    { 10, "Jane Smith", "STU Grocery" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Acme Foods" },
                    { 2, "Global Ingredients" },
                    { 3, "Organic Farms Inc." },
                    { 4, "Gourmet Foods" },
                    { 5, "Premium Ingredients" },
                    { 6, "Food Service Distributors" },
                    { 7, "Sysco Corporation" },
                    { 8, "US Foods Inc." },
                    { 9, "Gordon Food Service" },
                    { 10, "Performance Food Group" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "CustomerId", "DiscountAmount", "ExpirationDate", "UsageCount" },
                values: new object[,]
                {
                    { 1, "SUMMER25", 1, 25.00m, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, "FALL20", 2, 20.00m, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 3, "WINTER15", 3, 15.00m, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 4, "SPRING10", 4, 10.00m, new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 5, "NEWYEAR30", 5, 30.00m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, "MEMORIAL20", 6, 20.00m, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 7, "LABORDAY15", 7, 15.00m, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 8, "HALLOWEEN10", 8, 10.00m, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, "BLACKFRIDAY25", 9, 25.00m, new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, "CYBERMONDAY20", 10, 20.00m, new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 11, "CHRISTMAS30", 11, 30.00m, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, "VALENTINE15", 12, 15.00m, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 13, "EASTER10", 13, 10.00m, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 14, "MOTHERSDAY25", 14, 25.00m, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 15, "FATHERSDAY20", 15, 20.00m, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 }
                });

            migrationBuilder.InsertData(
                table: "CustomerMenuItems",
                columns: new[] { "CustomerId", "MenuItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryDrivers",
                columns: new[] { "Id", "Name", "PhoneNumber", "StoreId", "VehicleInformation" },
                values: new object[,]
                {
                    { 1, "John Smith", "555-1234", 1, "2018 Honda Civic" },
                    { 2, "Jane Doe", "555-5678", 2, "2020 Toyota Camry" },
                    { 3, "Bob Johnson", "555-9012", 3, "2019 Ford F-150" },
                    { 4, "Sarah Lee", "555-3456", 4, "2017 Nissan Altima" },
                    { 5, "David Kim", "555-7890", 5, "2021 Honda Accord" },
                    { 6, "Maria Hernandez", "555-2345", 6, "2016 Toyota Corolla" },
                    { 7, "Tom Wilson", "555-6789", 7, "2017 Ford Escape" },
                    { 8, "Emily Chen", "555-0123", 8, "2018 Honda CR-V" },
                    { 9, "Amy Nguyen", "555-8901", 9, "2020 Nissan Rogue" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "LocationId", "Name", "PhoneNumber", "Position" },
                values: new object[,]
                {
                    { 1, 1, "John Smith", "555-1234", "Manager" },
                    { 3, 2, "Bob Johnson", "555-2468", "Cook" },
                    { 4, 3, "Sue Davis", "555-7890", "FoodPrep" },
                    { 5, 4, "Mike Brown", "555-1357", "DeliveryDriver" },
                    { 6, 5, "Mary Williams", "555-3690", "Cleaner" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Cost", "InventoryId", "Name", "SupplierId" },
                values: new object[,]
                {
                    { 1, 0.99m, null, "Flour", 1 },
                    { 3, 0.50m, null, "Salt", 2 },
                    { 4, 2.50m, null, "Butter", 3 },
                    { 5, 3.00m, null, "Eggs", 4 },
                    { 6, 1.50m, null, "Milk", 5 },
                    { 7, 0.99m, null, "Baking powder", 6 },
                    { 8, 0.50m, null, "Baking soda", 7 },
                    { 9, 1.99m, null, "Vanilla extract", 8 },
                    { 10, 2.99m, null, "Chocolate chips", 9 },
                    { 11, 2.50m, null, "Cocoa powder", 10 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CustomerId", "PaymentAmount", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 1, 50.0m, "CreditCard" },
                    { 2, 2, 25.0m, "Cash" },
                    { 3, 3, 75.0m, "MobilePayment" },
                    { 4, 4, 100.0m, "GiftCards" },
                    { 5, 5, 60.0m, "DigitalWallets" },
                    { 6, 6, 80.0m, "Cryptocurrency" },
                    { 7, 7, 30.0m, "Checks" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "AdditionalCost", "Description", "Name", "PizzaId" },
                values: new object[,]
                {
                    { 1, 1.50m, "Spicy cured pork sausage", "Pepperoni", 1 },
                    { 2, 0.75m, "Sliced mushrooms", "Mushrooms", 1 },
                    { 3, 0.75m, "Sliced green bell peppers", "Green Peppers", 2 },
                    { 4, 0.75m, "Sliced onions", "Onions", 2 },
                    { 5, 1.50m, "Ground pork sausage", "Sausage", 3 },
                    { 6, 1.50m, "Crispy bacon bits", "Bacon", 3 },
                    { 7, 0.75m, "Sliced black olives", "Black Olives", 4 },
                    { 8, 0.75m, "Sliced jalapeno peppers", "Jalapenos", 4 },
                    { 9, 0.75m, "Diced pineapple chunks", "Pineapple", 5 },
                    { 10, 1.50m, "Diced ham pieces", "Ham", 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DeliveryDriverId", "DeliveryOptions", "OrderDate", "OrderTime", "TotalCost" },
                values: new object[,]
                {
                    { 1, 1, 1, "Standard", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922009), 50.0m },
                    { 2, 2, 1, "InStorePickup", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922099), 25.0m },
                    { 3, 2, 3, "WhiteGlove", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922111), 75.0m },
                    { 4, 4, 2, "WhiteGlove", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922122), 100.0m },
                    { 5, 3, 5, "InStorePickup", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922132), 60.0m },
                    { 6, 6, 3, "InStorePickup", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922144), 80.0m },
                    { 7, 4, 7, "Standard", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922154), 30.0m },
                    { 8, 5, 8, "Express", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922164), 90.0m },
                    { 9, 9, 4, "CurbsidePickup", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922174), 120.0m },
                    { 10, 6, 9, "Express", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922185), 70.0m },
                    { 11, 7, 2, "CurbsidePickup", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922195), 50.0m },
                    { 12, 12, 5, "Express", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922205), 25.0m },
                    { 13, 8, 1, "WhiteGlove", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922215), 75.0m },
                    { 14, 14, 6, "WhiteGlove", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922225), 100.0m },
                    { 15, 9, 3, "Standard", new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(627494922234), 60.0m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 9.99m, 2 },
                    { 2, 2, 11.99m, 1 },
                    { 3, 3, 7.99m, 3 },
                    { 4, 4, 12.99m, 2 },
                    { 5, 5, 10.99m, 1 },
                    { 6, 6, 13.99m, 2 },
                    { 7, 7, 14.99m, 1 },
                    { 8, 8, 11.99m, 3 },
                    { 9, 9, 8.99m, 1 },
                    { 10, 10, 15.99m, 2 },
                    { 11, 11, 10.99m, 1 },
                    { 12, 12, 9.99m, 3 },
                    { 13, 13, 13.99m, 2 },
                    { 14, 14, 10.99m, 1 },
                    { 15, 15, 8.99m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_CustomerId",
                table: "Coupons",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMenuItems_MenuItemId",
                table: "CustomerMenuItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDrivers_StoreId",
                table: "DeliveryDrivers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationId",
                table: "Employees",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_SupplierId",
                table: "Ingredients",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryDriverId",
                table: "Orders",
                column: "DeliveryDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaId",
                table: "Toppings",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "CustomerMenuItems");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DeliveryDrivers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
