using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Model
{
    public class tbl_FundTransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransferId { get; set; }

        public int SrcAccountNumber { get; set; }

        public int DestAccountNumber { get; set; }

        public int DestAccTypeId { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string? DestAccType { get; set; }

        public int TransferAmount { get; set; }
    }
}
