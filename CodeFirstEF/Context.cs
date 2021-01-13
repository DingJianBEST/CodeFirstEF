using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEF
{
    public class Context : DbContext
    {
        public Context() : base("name=CodeFirstEF")
        {
        }

        public DbSet<Donator> Donators { get; set; }
        public DbSet<PayWay> PayWays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donator>().ToTable("Donators").HasKey(m => m.DonatorId);//映射到表Donators,DonatorId当作主键对待
            modelBuilder.Entity<Donator>().Property(m => m.DonatorId).HasColumnName("Id");//映射到数据表中的主键名为Id而不是DonatorId
            modelBuilder.Entity<Donator>().Property(m => m.Name)
                .IsRequired()//设置Name是必须的，即不为null,默认是可为null的
                .IsUnicode()//设置Name列为Unicode字符，实际上默认就是unicode,所以该方法可不写
                .HasMaxLength(10);//最大长度为10

            base.OnModelCreating(modelBuilder);
        }
    }
}
