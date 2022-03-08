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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}