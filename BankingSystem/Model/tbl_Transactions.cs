using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Model
{
    public class tbl_Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        public int AccountNumber { get; set; }

        public int AccTypeId { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string? AccountType { get; set; }

        public int TranTypeId { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string? TranType { get; set; }

        public DateTime TranDate { get; set; }

        public int Amount { get; set; }

    }
}
