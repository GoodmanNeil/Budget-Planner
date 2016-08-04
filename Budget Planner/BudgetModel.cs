using Microsoft.Data.Entity;
using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Budget_Planner
{
    public class BudgetModel 
    {
        public class Account
        {
            public Account()
            {
                this.BillsAndPayments = new ObservableCollection<BillAndPayment>();
            }
            public int AccountID { get; set; }
            public string AccountName { get; set; }
            public decimal OpeningBalance { get; set; }

            public int AccountTypeID { get; set; }
            public virtual AccountType AccountType { get; set; }

            public ObservableCollection<BillAndPayment> BillsAndPayments { get; private set; }
        }

        public class AccountType
        {
            public AccountType()
            {
                this.Accounts = new ObservableCollection<Account>();
            }

            public int AccountTypeID { get; set; }
            public string AccountTypeName { get; set; }

            public virtual ObservableCollection<Account> Accounts { get; private set; }
        }

        public class BillAndPayment
        {
            public int BillAndPaymentID { get; set; }
            public string Description { get; set; }
            public decimal Amount { get; set; }
            public int Frequency { get; set; }

            public int AccountID { get; set; }
            public virtual Account Account { get; set; }

            public int BillAndPaymentTypeID { get; set; }
            public virtual BillAndPaymentType BillAndPaymentType { get; set; }

            public int FrequencyID { get; set; }
            public virtual FrequencyType FrequencyType { get; set; }
        }

        public class BillAndPaymentType
        {
            public BillAndPaymentType()
            {
                this.BillsAndPayments = new ObservableCollection<BillAndPayment>();
            }
            public int BillAndPaymentTypeID { get; set; }
            public string Description { get; set; }

            public int TransactionTypeID { get; set; }
            public virtual TransactionType TransactionType { get; set; }

            public virtual ObservableCollection<BillAndPayment> BillsAndPayments { get; private set; }
        }

        public class FrequencyType
        {
            public FrequencyType()
            {
                this.BillAndPaymentTypes = new ObservableCollection<BillAndPaymentType>();
            }
            public int FrequencyTypeID { get; set; }
            public string Description { get; set; }

            public virtual ObservableCollection<BillAndPaymentType> BillAndPaymentTypes { get; private set; }
        }

        public class TransactionType
        {
            public TransactionType()
            {
                this.BillsAndPayments = new ObservableCollection<BillAndPayment>();
                this.Transactions = new ObservableCollection<Transaction>();
                this.TransactionDescriptions = new ObservableCollection<TransactionDescription>();
            }
            public int TransactionTypeID { get; set; }
            public string Description { get; set; }

            public virtual ObservableCollection<BillAndPayment> BillsAndPayments { get; private set; }
            public virtual ObservableCollection<Transaction> Transactions { get; private set; }
            public virtual ObservableCollection<TransactionDescription> TransactionDescriptions { get; private set; }
        }

        public class ShoppingItem
        {
            public ShoppingItem()
            {
                this.ShoppingLists = new ObservableCollection<ShoppingList>();
            }

            public int ShoppingItemID { get; set; }
            public string Description { get; set; }

            public virtual ObservableCollection<ShoppingList> ShoppingLists { get; private set; }
        }

        public class ShoppingList
        {
            public ShoppingList()
            {
                this.Transactions = new ObservableCollection<Transaction>();
            }

            public int ShoppingListID { get; set; }
            public int ItemID { get; set; }
            public decimal Estimate { get; set; }
            public decimal Actual { get; set; }
            public float Quantity { get; set; }

            public int TransactionID { get; set; }
            public virtual Transaction Transaction { get; set; }

            public int ShoppingItemID { get; set; }
            public virtual ShoppingItem ShoppingItem { get; set; }

            public int AccountID { get; set; }
            public virtual Account Account { get; set; }

            public virtual ObservableCollection<Transaction> Transactions { get; private set; }
        }

        public class Transaction
        {
            public int TransactionID { get; set; }
            public DateTime TransDate { get; set; }
            public decimal Estimate { get; set; }
            public decimal Actual { get; set; }

            public int TransTypeID { get; set; }
            public virtual TransactionType TransactionType { get; set; }

            public int TransactionDescID { get; set; }
            public virtual TransactionDescription TransactionDescription { get; set; }

            public int AccountID { get; set; }
            public virtual Account Account { get; set; }
        }

        public class TransactionDescription
        {
            public TransactionDescription()
            {
                this.Transactions = new ObservableCollection<Transaction>();
            }
            public int TransactionDescriptionID { get; set; }
            public string Description { get; set; }

            public int TransTypeID { get; set; }
            public virtual TransactionType TransactionType { get; set; }

            public virtual ObservableCollection<Transaction> Transactions { get; private set; }
        }
    }
}
