using System;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billing_system_core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ParentCategory = table.Column<string>(type: "text", nullable: false),
                    Companies = table.Column<string>(type: "text", nullable: false),
                    OneItemPerOrder = table.Column<bool>(type: "boolean", nullable: false),
                    OneItemPerCustomer = table.Column<bool>(type: "boolean", nullable: false),
                    AllowAssetManagement = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DecimalQuantity = table.Column<bool>(type: "boolean", nullable: false),
                    StandardAvailability = table.Column<bool>(type: "boolean", nullable: false),
                    AvailableAccountTypes = table.Column<string>(type: "text", nullable: false),
                    AssetManagement = table.Column<bool>(type: "boolean", nullable: false),
                    Companies = table.Column<string>(type: "text", nullable: false),
                    ProductCode = table.Column<string>(type: "text", nullable: false),
                    GlCode = table.Column<string>(type: "text", nullable: false),
                    StandardAgentCommission = table.Column<float>(type: "real", nullable: false),
                    MasterAgentCommission = table.Column<float>(type: "real", nullable: false),
                    ExcludedCategories = table.Column<string>(type: "text", nullable: false),
                    AvailableStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AvailableEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReservationDuration = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<BigInteger>(type: "numeric", nullable: false),
                    ManualPricing = table.Column<bool>(type: "boolean", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
