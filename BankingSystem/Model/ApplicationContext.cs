using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Model
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        { }
        public DbSet<tbl_Accounts>tbl_Accounts { get; set; }

        public DbSet<tbl_Checkbookdtls> tbl_Checkbookdtls { get; set; }

        public DbSet<Tbl_Atmdtls> tbl_Atmdtls { get; set; }

        public DbSet<tbl_FundTransfer> tbl_FundTransfers { get; set; }

        public DbSet<tbl_TransactionMap> tbl_TransactionMaps { get; set; }

        public DbSet<tbl_Transactions> tbl_Transactions { get; set; }

        public DbSet<User> User { get; set; }
    }
}
