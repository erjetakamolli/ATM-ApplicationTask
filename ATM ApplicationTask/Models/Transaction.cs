using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM_ApplicationTask.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        public int TransactionId { get; set; } //Primary Key
        public int AccountId { get; set; } //Foreign Key
        public string TransactionUniqueReference { get; set; } //do te gjeneroj ne cdo instance te klases 0 references
        public decimal TransactionAmount { get; set; } //shuma per transaksionin qe do tkryhet
        public TranStatus TransactionStatus { get; set; } //tregon nese transaksioni eshte kryer me sukses apo ka deshtuar
        public bool IsSuccessful => TransactionStatus.Equals(TranStatus.Succes); //varet nga vlera e statusit
        public string TransactionSourceAccount { get; set; } //llogaria qe ka kryer transaksionin
        //public string TransactionDestinationAccount { get; set; }
        public TranType TransactionType { get; set; } // lloji i transaksionit qe do te kryhet

        public DateTime TransactionDate { get; set; }

        public Transaction()
        {
            TransactionUniqueReference = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 27)}"; //guid per ta gjeneruar
        }
    }
    public enum TranStatus
    {
        Failed,
        Succes,
        Error
    }

    public enum TranType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}