using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Model
{
    public class tbl_Checkbookdtls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int checkbookId { get; set; }
        
        public int AccountNumber { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime IssueDate { get; set; }

    }
}
