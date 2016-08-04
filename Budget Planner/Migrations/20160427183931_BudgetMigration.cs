using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Budget_Planner.Migrations
{
    public partial class BudgetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    AccountTypeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.AccountTypeID);
                });
            migrationBuilder.CreateTable(
                name: "FrequencyType",
                columns: table => new
                {
                    FrequencyTypeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequencyType", x => x.FrequencyTypeID);
                });
            migrationBuilder.CreateTable(
                name: "ShoppingItem",
                columns: table => new
                {
                    ShoppingItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItem", x => x.ShoppingItemID);
                });
            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    TransactionTypeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransactionTypeID);
                });
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountName = table.Column<string>(nullable: true),
                    AccountTypeID = table.Column<int>(nullable: false),
                    OpeningBalance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Account_AccountType_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "AccountType",
                        principalColumn: "AccountTypeID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "BillAndPaymentType",
                columns: table => new
                {
                    BillAndPaymentTypeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    FrequencyTypeFrequencyTypeID = table.Column<int>(nullable: true),
                    TransactionTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillAndPaymentType", x => x.BillAndPaymentTypeID);
                    table.ForeignKey(
                        name: "FK_BillAndPaymentType_FrequencyType_FrequencyTypeFrequencyTypeID",
                        column: x => x.FrequencyTypeFrequencyTypeID,
                        principalTable: "FrequencyType",
                        principalColumn: "FrequencyTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillAndPaymentType_TransactionType_TransactionTypeID",
                        column: x => x.TransactionTypeID,
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TransactionDescription",
                columns: table => new
                {
                    TransactionDescriptionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    TransTypeID = table.Column<int>(nullable: false),
                    TransactionTypeTransactionTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDescription", x => x.TransactionDescriptionID);
                    table.ForeignKey(
                        name: "FK_TransactionDescription_TransactionType_TransactionTypeTransactionTypeID",
                        column: x => x.TransactionTypeTransactionTypeID,
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "BillAndPayment",
                columns: table => new
                {
                    BillAndPaymentID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountID = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    BillAndPaymentTypeID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Frequency = table.Column<int>(nullable: false),
                    FrequencyID = table.Column<int>(nullable: false),
                    FrequencyTypeFrequencyTypeID = table.Column<int>(nullable: true),
                    TransactionTypeTransactionTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillAndPayment", x => x.BillAndPaymentID);
                    table.ForeignKey(
                        name: "FK_BillAndPayment_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillAndPayment_BillAndPaymentType_BillAndPaymentTypeID",
                        column: x => x.BillAndPaymentTypeID,
                        principalTable: "BillAndPaymentType",
                        principalColumn: "BillAndPaymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillAndPayment_FrequencyType_FrequencyTypeFrequencyTypeID",
                        column: x => x.FrequencyTypeFrequencyTypeID,
                        principalTable: "FrequencyType",
                        principalColumn: "FrequencyTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillAndPayment_TransactionType_TransactionTypeTransactionTypeID",
                        column: x => x.TransactionTypeTransactionTypeID,
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    ShoppingListID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountID = table.Column<int>(nullable: false),
                    Actual = table.Column<decimal>(nullable: false),
                    Estimate = table.Column<decimal>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    Quantity = table.Column<float>(nullable: false),
                    ShoppingItemID = table.Column<int>(nullable: false),
                    TransactionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.ShoppingListID);
                    table.ForeignKey(
                        name: "FK_ShoppingList_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingList_ShoppingItem_ShoppingItemID",
                        column: x => x.ShoppingItemID,
                        principalTable: "ShoppingItem",
                        principalColumn: "ShoppingItemID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountID = table.Column<int>(nullable: false),
                    Actual = table.Column<decimal>(nullable: false),
                    Estimate = table.Column<decimal>(nullable: false),
                    ShoppingListShoppingListID = table.Column<int>(nullable: true),
                    TransDate = table.Column<DateTime>(nullable: false),
                    TransTypeID = table.Column<int>(nullable: false),
                    TransactionDescID = table.Column<int>(nullable: false),
                    TransactionDescriptionTransactionDescriptionID = table.Column<int>(nullable: true),
                    TransactionTypeTransactionTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_ShoppingList_ShoppingListShoppingListID",
                        column: x => x.ShoppingListShoppingListID,
                        principalTable: "ShoppingList",
                        principalColumn: "ShoppingListID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionDescription_TransactionDescriptionTransactionDescriptionID",
                        column: x => x.TransactionDescriptionTransactionDescriptionID,
                        principalTable: "TransactionDescription",
                        principalColumn: "TransactionDescriptionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeTransactionTypeID",
                        column: x => x.TransactionTypeTransactionTypeID,
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Transaction_TransactionID",
                table: "ShoppingList",
                column: "TransactionID",
                principalTable: "Transaction",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ShoppingList_Account_AccountID", table: "ShoppingList");
            migrationBuilder.DropForeignKey(name: "FK_Transaction_Account_AccountID", table: "Transaction");
            migrationBuilder.DropForeignKey(name: "FK_ShoppingList_ShoppingItem_ShoppingItemID", table: "ShoppingList");
            migrationBuilder.DropForeignKey(name: "FK_Transaction_ShoppingList_ShoppingListShoppingListID", table: "Transaction");
            migrationBuilder.DropTable("BillAndPayment");
            migrationBuilder.DropTable("BillAndPaymentType");
            migrationBuilder.DropTable("FrequencyType");
            migrationBuilder.DropTable("Account");
            migrationBuilder.DropTable("AccountType");
            migrationBuilder.DropTable("ShoppingItem");
            migrationBuilder.DropTable("ShoppingList");
            migrationBuilder.DropTable("Transaction");
            migrationBuilder.DropTable("TransactionDescription");
            migrationBuilder.DropTable("TransactionType");
        }
    }
}
