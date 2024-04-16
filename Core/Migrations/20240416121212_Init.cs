using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    last_name = table.Column<string>(type: "TEXT", nullable: false),
                    patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number = table.Column<string>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    position = table.Column<string>(type: "TEXT", nullable: false),
                    salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    birth_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    recruit_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    quit_date = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "employee_id", "address", "birth_date", "first_name", "last_name", "patronymic", "phone_number", "position", "quit_date", "recruit_date", "salary", "status" },
                values: new object[,]
                {
                    { new Guid("0c1e0bce-3fb4-4e56-8528-e929c1fbcf37"), "123 Main St", new DateTime(1987, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Smith", "Michael", "111-222-3333", "Manager", null, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 55000m, 0 },
                    { new Guid("776ac3a7-267b-48fd-b29f-f188a3c61746"), "просп. Перемоги, буд. 5", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "Sidrenko", "Petrovna", "987-654-3210", "Розробник", new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 60000m, 1 },
                    { new Guid("f786689b-4484-425a-9dff-39a0851a2a3c"), "456 Elm St", new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe", "Marie", "555-666-7777", "Developer", null, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 65000m, 0 },
                    { new Guid("fcd881e5-61e0-4237-b21a-37fac3195e53"), "вул. Гагаріна, буд. 10", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Snow", null, "123-456-7890", "Менеджер", null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
