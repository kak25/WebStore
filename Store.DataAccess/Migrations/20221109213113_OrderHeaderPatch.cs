using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.Migrations
{
    public partial class OrderHeaderPatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserID",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_ApplicationUserID",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "Shippingdate",
                table: "OrderHeaders",
                newName: "ShippingDate");

            migrationBuilder.RenameColumn(
                name: "Carries",
                table: "OrderHeaders",
                newName: "Carrier");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentIntentId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "OrderHeaders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                table: "OrderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "ShippingDate",
                table: "OrderHeaders",
                newName: "Shippingdate");

            migrationBuilder.RenameColumn(
                name: "Carrier",
                table: "OrderHeaders",
                newName: "Carries");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentIntentId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "OrderHeaders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserID",
                table: "OrderHeaders",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_AspNetUsers_ApplicationUserID",
                table: "OrderHeaders",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
