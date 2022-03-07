using DGCARTEL.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DGCARTEL.DAL
{
    public class DGCARTELContext : DbContext
    {
        public DGCARTELContext() : base("MyConnStrNm")
        {
        }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<PageMetaDetail> PageMetaDetail { get; set; }
        public DbSet<tblUser> tblUser { get; set; }
       // public DbSet<USER_DETAILS1> USER_DETAILS { get; set; }
        public DbSet<PAYUMONEY_DATA> PAYUMONEY_DATA { get; set; }
        public  DbSet<PAYUMONEY_FAIL_DATA> PAYUMONEY_FAIL_DATA { get; set; }
        public  DbSet<PAYUMONEY_LOG> PAYUMONEY_LOG { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}