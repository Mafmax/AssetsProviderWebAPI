using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mafmax.AssetsProvider.DAL.Migrations
{
    public partial class AddInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Issuers_IssuerId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_StockExchange_StockId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuers_Countries_CountryId",
                table: "Issuers");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuers_Industries_IndustryId",
                table: "Issuers");

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "Issuers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Issuers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IssuerId",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Россия" },
                    { 2, "США" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Технологии" },
                    { 2, "Финансы" },
                    { 3, "Добыча ископаемых" },
                    { 4, "Нефть и газ" },
                    { 5, "Телекоммуникации" },
                    { 6, "IT" }
                });

            migrationBuilder.InsertData(
                table: "StockExchange",
                columns: new[] { "Id", "Key", "Name" },
                values: new object[] { 1, "MOEX", "Московская биржа" });

            migrationBuilder.InsertData(
                table: "Issuers",
                columns: new[] { "Id", "CountryId", "IndustryId", "Name" },
                values: new object[,]
                {
                    { 4, 2, 1, "Apple" },
                    { 6, 1, 2, "Сбербанк России" },
                    { 3, 1, 3, "Алроса" },
                    { 2, 1, 4, "Сургутнефтегаз" },
                    { 1, 1, 5, "МТС" },
                    { 5, 1, 6, "Яндекс" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "BaseCurrency", "Discriminator", "ISIN", "IsPreffered", "IssuerId", "LotSize", "Name", "StockId", "Ticker", "EndCirculation", "StartCirculation" },
                values: new object[] { 5, "USD", "Share", "US0378331005", false, 4, 1, "Apple, акция обыкновенная", 1, "AAPL-RM", null, new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "BaseCurrency", "Discriminator", "ISIN", "IssuerId", "LotSize", "Name", "StockId", "Ticker", "Type", "EndCirculation", "StartCirculation" },
                values: new object[,]
                {
                    { 8, "RUB", "Bond", "RU000A101C89", 6, 1, "Сбербанк ПАО 001Р-SBER15", 1, "RU000A101C89", 2, null, new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "RUB", "Bond", "RU000A1013J4", 6, 1, "СберИОС 001Р-177R GMKN 100", 1, "RU000A1013J4", 2, null, new DateTime(2019, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "BaseCurrency", "Discriminator", "ISIN", "IsPreffered", "IssuerId", "LotSize", "Name", "StockId", "Ticker", "EndCirculation", "StartCirculation" },
                values: new object[,]
                {
                    { 1, "RUB", "Share", "RU0009029557", true, 6, 10, "Сбербанк России, акция привелегированная", 1, "SBERP", null, new DateTime(2016, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "RUB", "Share", "RU0009029540", false, 6, 10, "Сбербанк России, акция обыкновенная", 1, "SBER", null, new DateTime(2007, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "RUB", "Share", "RU0007252813", false, 3, 10, "Алроса, акция обыкновенная", 1, "ALRS", null, new DateTime(2011, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "RUB", "Share", "RU0008926258", false, 2, 100, "Сургутнефтегаз, акция обыкновенная", 1, "SNGS", null, new DateTime(2005, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "RUB", "Share", "RU0007775219", false, 1, 10, "МТС, акция обыкновенная", 1, "MTSS", null, new DateTime(2004, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "EUR", "Share", "NL0009805522", false, 5, 1, "ЯНДЕКС Н.В., акция обыкновенная", 1, "YNDX", null, new DateTime(2014, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Issuers_IssuerId",
                table: "Assets",
                column: "IssuerId",
                principalTable: "Issuers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_StockExchange_StockId",
                table: "Assets",
                column: "StockId",
                principalTable: "StockExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issuers_Countries_CountryId",
                table: "Issuers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issuers_Industries_IndustryId",
                table: "Issuers",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Issuers_IssuerId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_StockExchange_StockId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuers_Countries_CountryId",
                table: "Issuers");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuers_Industries_IndustryId",
                table: "Issuers");

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Issuers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Issuers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Issuers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Issuers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Issuers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Issuers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StockExchange",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Industries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "IndustryId",
                table: "Issuers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Issuers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "Assets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IssuerId",
                table: "Assets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Issuers_IssuerId",
                table: "Assets",
                column: "IssuerId",
                principalTable: "Issuers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_StockExchange_StockId",
                table: "Assets",
                column: "StockId",
                principalTable: "StockExchange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issuers_Countries_CountryId",
                table: "Issuers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issuers_Industries_IndustryId",
                table: "Issuers",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
