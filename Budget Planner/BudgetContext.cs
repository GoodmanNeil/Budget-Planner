using Microsoft.Data.Entity;
using System.Collections.Generic;
using static Budget_Planner.BudgetModel;

namespace Budget_Planner
{
    public class BudgetContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BillAndPayment> BillsAndPayments { get; set; }
        public DbSet<BillAndPaymentType> BillAndPaymentTypes { get; set; }
        public DbSet<FrequencyType> FrequencyTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDescription> TransactionDescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Budget.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Make Keys
            // Make Account.AccountID required
            modelBuilder.Entity<Account>()
                .Property(b => b.AccountID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make AccountType.AccountTypeID required
            modelBuilder.Entity<AccountType>()
                .Property(b => b.AccountTypeID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make BillAndPayment.BillAndPaymentID required
            modelBuilder.Entity<BillAndPayment>()
                .Property(b => b.BillAndPaymentID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make BillAndPaymentType.BillAndPaymentTypeID required
            modelBuilder.Entity<BillAndPaymentType>()
                .Property(b => b.BillAndPaymentTypeID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make FrequencyType.FrequencyTypeID required
            modelBuilder.Entity<FrequencyType>()
                .Property(b => b.FrequencyTypeID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make TransactionType.TransactionTypeID required
            modelBuilder.Entity<TransactionType>()
                .Property(b => b.TransactionTypeID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make ShoppingItem.ShoppingItemID required
            modelBuilder.Entity<ShoppingItem>()
                .Property(b => b.ShoppingItemID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make ShoppingList.ShoppingListID required
            modelBuilder.Entity<ShoppingList>()
                .Property(b => b.ShoppingListID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make ShoppingList.TransactionID required
            modelBuilder.Entity<ShoppingList>()
                .Property(b => b.TransactionID)
                .IsRequired();
            // Make ShoppingList.ItemID required
            modelBuilder.Entity<ShoppingList>()
                .Property(b => b.ItemID)
                .IsRequired();
            // Make Transaction.TransactionID required
            modelBuilder.Entity<Transaction>()
                .Property(b => b.TransactionID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            // Make TransactionDescription.TransactionDescID required
            modelBuilder.Entity<TransactionDescription>()
                .Property(b => b.TransactionDescriptionID)
                .ValueGeneratedOnAdd()
                .IsRequired();
        }

    }
}
