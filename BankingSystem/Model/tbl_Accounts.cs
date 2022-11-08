using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Model
{
    public class tbl_Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int AccTypeId { get; set; }

        [StringLength(100)]
        public string? AccType { get; set; }

    }
}
