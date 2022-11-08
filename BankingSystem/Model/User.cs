using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Model
{
    public class User
    {
        [Key]
        public int AccountNumber { get; set; }

        [StringLength(150)]
        public string? FirstName { get; set; }

        [StringLength(150)]
        public string? MiddleName { get; set; }

        [StringLength(150)]
        public string? LastName { get; set; }

        [StringLength(150)]
        public string? UserName { get; set; }

        [StringLength(150)]
        public string? Password { get; set; }

        [StringLength(1000)]
        public string? SecurityQuestion { get; set; }

        [StringLength(1000)]
        public string? SecurityAnswer { get; set; }

        public int AccTypeId  { get; set; }

        [NotMapped]
        [StringLength(100)]
        public string? AccType { get; set; }

        public int MobileNumber { get; set; }

        public int Amount { get; set; }
    }
}
