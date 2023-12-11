using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Showcase",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16012ef7-8308-420f-bc00-45ad2ba78c18", "AQAAAAIAAYagAAAAEAC+K4VLUlnvKwaHULfo3qWv+mfknIHeqhLMcDfuMDgiSuGG1rlU5C/FlbdBtKXctg==", "5a15030d-2ef1-496e-bb1a-6cebcbe98613" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90be40f9-0373-4bb0-95b2-b7a49abc1b79", "AQAAAAIAAYagAAAAEAWlH2medp7bYQYPtIdBEHas/khVpPlM2Wsq/SnO6UJXdoIp8kvWgu6/rGRlM8gYyA==", "f9053e61-365c-4803-92db-c0f1f0fe1623" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f278cb02-3977-4a1a-b688-a7aa6af193c3", "AQAAAAIAAYagAAAAEJG/ZXcgVT1q9XBSky0Sfn6TWLgrfQ6hxDxbejIxQFNo8UfNWoG8jI1zk1Rqq6puUw==", "911af997-fd5e-4d54-9f71-a39e4dbc2856" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2aee863-4132-4f3c-808f-02263beb3b3c", "AQAAAAIAAYagAAAAEArpjEI99mkJiKLaocUQu0WnmNDr2C6JEex+eBsXeo/aUF7m7ZI+N5CLPj1o6Hr5NA==", "9b4fe8a3-a1c5-4a63-b67f-56254405f10a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c258bbeb-239f-4f5f-a98b-6d6b04b4d7f7", "AQAAAAIAAYagAAAAEFrnrg5dDBYOP83Uc7xEkmdc1MLUaRV9UtnyHQE1XGbe4YqXCV/pURa3p2yWkkZVlg==", "d7031ebb-48d5-4a89-952d-d8d7db85908a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "527403eb-603e-4c45-a67a-a4102e87f007", "AQAAAAIAAYagAAAAEEsicUcgHuMmQepETxTEgiTziiO4X32x+3K5Oy1+qrri3IfBKX5bVwKL4Jk+gNS11w==", "0fe1b922-8a6f-48ad-b5de-7c23b54f3fae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b08a09a-fe5f-49f0-ade1-80029ad1a3f4", "AQAAAAIAAYagAAAAEPMx+IgoMNwOB+F6HJr/GnxMvvfQpQBWLUYIjfyS57b59w4OQgbY7DYCDIQixVwhtg==", "37db50d1-2acf-42c4-bd80-bdecb4339c74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ab4bf49-a3da-459c-b5b6-1bc93fbbf2e4", "AQAAAAIAAYagAAAAEJKx8eZ2nmrCLeiiE3MK+UXjaFGBkBZ3UOMvT282xlYpASJUzMcmrajdOBL8HtQGKg==", "39c920b2-0621-461e-a728-35e671a62f5f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc1cc131-4efc-4271-b989-d85c45eca770", "AQAAAAIAAYagAAAAEOUWww0bTqjeKfDw6TKC8MReracV+YvoTCxxLcKSvPy+3RatXE76fWIZlxhmIbGfFg==", "04328912-4b09-4d88-93c7-63d6776bc8a5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Showcase",
                table: "Files");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc8abb53-e961-4ad6-8f5e-3a87b2b1cc1c", "AQAAAAIAAYagAAAAECC2YTB2123c9QNOOiZUHuPZyafgsNn7TIYIRi/wCMNsZL+JtJ6LSc9ztO5uyqdmdA==", "5811d4bd-f722-4490-9fcc-5b5e69a3dd1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ef84980-8777-4942-8ddb-6c6234e0c634", "AQAAAAIAAYagAAAAECrOVpnQoRzPuQqO8PBsp5ofMxvnYP9Smi1zBw0n0ivUW6tCfYqxt4bAD/ebrCRNzA==", "0b37f4bb-9fcd-4011-b740-6ce6a656b19c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c9d5a72-5adb-46e0-8017-314d8244695b", "AQAAAAIAAYagAAAAEIUZaWDUwEqt0X6/T9/f3OOdmciaJWyDrz7Vd4RoCi0xDHnvVfVcV5GTD2eoh0reUw==", "47b9a8aa-3e71-48c4-a34a-7fcac0be0057" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a0d70d0-5153-4334-a9e6-24222a5da1f0", "AQAAAAIAAYagAAAAEA70kdWXlZPkMqsjW0zgmX1ZsUNRWuQ/uPHhJ1cYu+i6WTAtJTGU4jqh+5c/OtyHrw==", "c235b6b8-ddc1-4432-9ff5-668dab0b3d1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a91efcce-7978-42a1-91cb-d43c75842140", "AQAAAAIAAYagAAAAEPkERMOPF69gz9G0H7DKJMrKTp4mEfn41v9p05Ttl+9Xd6g1FyATFG+oWLBj+/OUgg==", "736c19c9-5169-4259-aeb0-502e22824ca1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c6a383c-a6bf-4c5e-b8c4-3f8d20f1062c", "AQAAAAIAAYagAAAAEJiaIUb9dEMGl9WTywt+B9VDCZi15OGBzwzqlr9lEgqoPe7aVWpaVlWRPp/UC8EcZA==", "9d428a10-0736-402e-b1f0-c442fd89b6dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2d73c52-1ea2-4414-b3d9-7349349ab4fc", "AQAAAAIAAYagAAAAEDUo7EzHoOiIfczrxfZ0l0gbttzCT8trerdSlayftKrhMnclmvcOIgoSrez4BYD+mA==", "ffbe1b4f-0e07-460c-a67a-5f0aec4825ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "198a6ed9-560b-46d9-9f1f-4a20f620b81a", "AQAAAAIAAYagAAAAEPwALh6owmNRrpBQuOEUHZx7UiHJiQRqltZYrwHtvCfb5K+7xzyK+dqNRi+awDFcFA==", "4678050e-863b-4609-ab1a-d65a2ee1d930" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b80ffa4-b2d6-41f3-a65e-7128571d7417", "AQAAAAIAAYagAAAAEOmnkK2BbA0K6MEUCrlkRdvnKGIE1ssAdjot1p1FcuT4OTSGl+d6geaUvpVghCLdGA==", "8740ee7a-1efa-45b0-b7c1-37bded8f3708" });
        }
    }
}
