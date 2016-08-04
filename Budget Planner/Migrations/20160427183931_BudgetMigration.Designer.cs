using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Budget_Planner;

namespace Budget_Planner.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20160427183931_BudgetMigration")]
    partial class BudgetMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Budget_Planner.BudgetModel+Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<int>("AccountTypeID");

                    b.Property<decimal>("OpeningBalance");

                    b.HasKey("AccountID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+AccountType", b =>
                {
                    b.Property<int>("AccountTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountTypeName");

                    b.HasKey("AccountTypeID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+BillAndPayment", b =>
                {
                    b.Property<int>("BillAndPaymentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountID");

                    b.Property<decimal>("Amount");

                    b.Property<int>("BillAndPaymentTypeID");

                    b.Property<string>("Description");

                    b.Property<int>("Frequency");

                    b.Property<int>("FrequencyID");

                    b.Property<int?>("FrequencyTypeFrequencyTypeID");

                    b.Property<int?>("TransactionTypeTransactionTypeID");

                    b.HasKey("BillAndPaymentID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+BillAndPaymentType", b =>
                {
                    b.Property<int>("BillAndPaymentTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("FrequencyTypeFrequencyTypeID");

                    b.Property<int>("TransactionTypeID");

                    b.HasKey("BillAndPaymentTypeID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+FrequencyType", b =>
                {
                    b.Property<int>("FrequencyTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("FrequencyTypeID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+ShoppingItem", b =>
                {
                    b.Property<int>("ShoppingItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ShoppingItemID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+ShoppingList", b =>
                {
                    b.Property<int>("ShoppingListID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountID");

                    b.Property<decimal>("Actual");

                    b.Property<decimal>("Estimate");

                    b.Property<int>("ItemID");

                    b.Property<float>("Quantity");

                    b.Property<int>("ShoppingItemID");

                    b.Property<int>("TransactionID");

                    b.HasKey("ShoppingListID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountID");

                    b.Property<decimal>("Actual");

                    b.Property<decimal>("Estimate");

                    b.Property<int?>("ShoppingListShoppingListID");

                    b.Property<DateTime>("TransDate");

                    b.Property<int>("TransTypeID");

                    b.Property<int>("TransactionDescID");

                    b.Property<int?>("TransactionDescriptionTransactionDescriptionID");

                    b.Property<int?>("TransactionTypeTransactionTypeID");

                    b.HasKey("TransactionID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+TransactionDescription", b =>
                {
                    b.Property<int>("TransactionDescriptionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("TransTypeID");

                    b.Property<int?>("TransactionTypeTransactionTypeID");

                    b.HasKey("TransactionDescriptionID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("TransactionTypeID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+Account", b =>
                {
                    b.HasOne("Budget_Planner.BudgetModel+AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+BillAndPayment", b =>
                {
                    b.HasOne("Budget_Planner.BudgetModel+Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("Budget_Planner.BudgetModel+BillAndPaymentType")
                        .WithMany()
                        .HasForeignKey("BillAndPaymentTypeID");

                    b.HasOne("Budget_Planner.BudgetModel+FrequencyType")
                        .WithMany()
                        .HasForeignKey("FrequencyTypeFrequencyTypeID");

                    b.HasOne("Budget_Planner.BudgetModel+TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeTransactionTypeID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+BillAndPaymentType", b =>
                {
                    b.HasOne("Budget_Planner.BudgetModel+FrequencyType")
                        .WithMany()
                        .HasForeignKey("FrequencyTypeFrequencyTypeID");

                    b.HasOne("Budget_Planner.BudgetModel+TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+ShoppingList", b =>
                {
                    b.HasOne("Budget_Planner.BudgetModel+Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("Budget_Planner.BudgetModel+ShoppingItem")
                        .WithMany()
                        .HasForeignKey("ShoppingItemID");

                    b.HasOne("Budget_Planner.BudgetModel+Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+Transaction", b =>
                {
                    b.HasOne("Budget_Planner.BudgetModel+Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("Budget_Planner.BudgetModel+ShoppingList")
                        .WithMany()
                        .HasForeignKey("ShoppingListShoppingListID");

                    b.HasOne("Budget_Planner.BudgetModel+TransactionDescription")
                        .WithMany()
                        .HasForeignKey("TransactionDescriptionTransactionDescriptionID");

                    b.HasOne("Budget_Planner.BudgetModel+TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeTransactionTypeID");
                });

            modelBuilder.Entity("Budget_Planner.BudgetModel+TransactionDescription", b =>
                {
                    b.HasOne("Budget_Planner.BudgetModel+TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeTransactionTypeID");
                });
        }
    }
}
