namespace UserAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserContext : DbContext
    {
        public UserContext()
            : base("name=userDB")
        {
        }

        public virtual DbSet<roles> role { get; set; } 
        public virtual DbSet<users> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
