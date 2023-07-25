using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EBS.RepositoryLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin_Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    bill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bill_amount = table.Column<float>(type: "real", nullable: false),
                    bill_paymentMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bill_issuedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bill_payingdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bill_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bill_present_reading = table.Column<float>(type: "real", nullable: false),
                    bill_previous_reading = table.Column<float>(type: "real", nullable: false),
                    bill_energy_charge = table.Column<float>(type: "real", nullable: false),
                    bill_customerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.bill_id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    payment_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_amount = table.Column<float>(type: "real", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_billno = table.Column<int>(type: "int", nullable: false),
                    payment_issuedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bill_previous_reading = table.Column<float>(type: "real", nullable: false),
                    bill_energy_charge = table.Column<float>(type: "real", nullable: false),
                    consumption_unit = table.Column<float>(type: "real", nullable: false),
                    payment_tax = table.Column<float>(type: "real", nullable: false),
                    payment_billamount = table.Column<float>(type: "real", nullable: false),
                    payment_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_customerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.payment_no);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
