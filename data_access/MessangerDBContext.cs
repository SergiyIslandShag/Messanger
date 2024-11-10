using data_access.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access
{
    public class MessangerDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MessageInfo> MessangeInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"workstation id=Messengerrrrr.mssql.somee.com;packet size=4096;user id=Nikita35_SQLLogin_1;pwd=ukqyc6pkqg;data source=Messengerrrrr.mssql.somee.com;persist security info=False;initial catalog=Messengerrrrr;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(a => a.PhoneNumber).IsRequired();
            modelBuilder.Entity<User>().Property(a => a.Name).IsRequired(); 
            modelBuilder.Entity<MessageInfo>().Property(a => a.Text).IsRequired();
           
            modelBuilder.Entity<User>().HasMany(u=>u.Messages).WithOne(m=>m.User).HasForeignKey(f => f.UserId);
                
        }

    }
}
