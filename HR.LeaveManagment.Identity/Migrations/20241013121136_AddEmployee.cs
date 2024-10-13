using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagment.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57549ed9-32f0-4c07-8f3a-d57f9b460a3d", "AQAAAAIAAYagAAAAEP0aYLlGzgTcCYHqpUZrHcyWkzXunJ7iWdSxrw+4oW19Au46VdJisKWfvwUnm2td+w==", "4ea0f078-16f8-4969-a126-787646c17564" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e2bb68-33e4-4d2-b7b7-8574fva048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bc7f580-06e9-404c-a475-7e706002bc2d", "AQAAAAIAAYagAAAAEJbN8K/Cud7QhMcEoxODplKt0kaV1LnPwhA6VsGuH81HLp7iyryHbBS3XNwPLRPJzw==", "4e383a02-4717-456c-b082-46938c3295dc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3006be5a-b3f3-4ea6-a462-14a69cdddf21", "AQAAAAIAAYagAAAAEJ792dHjKah6hLYYD1gKWdl1fqQwJjRRCuDhidiJemExdV71ydwONOhGiq++zH9cqA==", "8d2e3ab3-c81c-4e0e-9a0c-91a09af417f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e2bb68-33e4-4d2-b7b7-8574fva048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9924ad5-ab5b-49c3-bb54-cf553f031254", "AQAAAAIAAYagAAAAEEunYLwmW9dgPwfPIAloS9OU37mOYH0dtRNPD7CPWO/hOZ+vYOgFFlqV8WO8Prn/Rw==", "2551bad9-4da7-4c17-82c5-9b177d735fa0" });
        }
    }
}
