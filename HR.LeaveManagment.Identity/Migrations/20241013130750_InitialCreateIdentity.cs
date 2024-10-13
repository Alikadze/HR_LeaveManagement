using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagment.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cacne43a6e-f72bb-4448-baaf-1ad1ccbbf", null, "Employee", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ea8db28-59f8-4425-859c-8dbdf090d841", "AQAAAAIAAYagAAAAEB+bg8yjTgl8WQyQYxb5OklAJpEtn4iS1YW4r7oCoI9e9zq5/bShwKtKuHsoY+r5og==", "6374eb01-5bd3-4695-9467-3e1e93f31644" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e2bb68-33e4-4d2-b7b7-8574fva048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14860abf-4384-4bdd-8f32-4487e73c9976", "AQAAAAIAAYagAAAAEEcBg1iNMmV4TVYcn73gLgkYuxaIXAy1rmdt4tYzDKMqIe9ECaG4eA3PAPKccsAUVg==", "7b8cf063-202a-41a2-a94a-f453793e8218" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9e623v-33e4-4d2-b7b7-8574fva048tcdb9", 0, "96adad69-5191-4317-8887-0ad619ce36b6", "employ@localhost.com", true, "System", "Employ", false, null, "EMPLOY@LOCALHOST.COM", "EMPLOYEE@LOCALHOST.COM", "AQAAAAIAAYagAAAAECGtP7arZFOWJF2hnBDOUsgTUOqQePq6gebHJg5TJ00AY0LXJSK4azu9BT5kwRx9hw==", null, false, "bf0c0b64-2a70-4f79-9ccc-17b323f2b9ef", false, "employ@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cacne43a6e-f72bb-4448-baaf-1ad1ccbbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e623v-33e4-4d2-b7b7-8574fva048tcdb9");

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
    }
}
