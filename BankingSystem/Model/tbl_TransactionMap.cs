using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Model
{
    public class tbl_TransactionMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int TranTypeId { get; set; }

        [StringLength(100)]
        public string? TranType { get; set; }

    }
}
