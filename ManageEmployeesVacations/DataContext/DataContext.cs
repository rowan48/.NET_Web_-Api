
using Microsoft.EntityFrameworkCore;
using Models;



namespace DataCon
{

    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Vacation> Vacation { get; set; }
        public DbSet<VacationRequest> VacationRequest { get; set; }
        public DbSet<EmployeeVacation> EmployeeVacation { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("user");
            //modelBuilder.Entity<UserInfo>().ToTable("userinfo");
            modelBuilder.Entity<EmployeeVacation>().ToTable("employee_vacation");

            modelBuilder.Entity<VacationRequest>().ToTable("vacation_request");
            modelBuilder.Entity<EmployeeVacation>()
                .HasKey(o => new { o.EmployeeID, o.VacationID });
            modelBuilder.Entity<Employee>().Property(x => x.FullName).IsRequired();

            modelBuilder.Entity<Employee>().Property(x => x.BirthDate).HasColumnType("Date")
           .IsRequired();
            modelBuilder.Entity<Gender>().Property(x => x.GenderType).IsRequired();
            modelBuilder.Entity<Vacation>().Property(x => x.VacationName).IsRequired();
            modelBuilder.Entity<Vacation>().Property(x => x.Balance).IsRequired();




            modelBuilder.Entity<VacationRequest>().Property(x => x.StartVacationDate).HasColumnType("Date")
           .IsRequired();
            modelBuilder.Entity<VacationRequest>().Property(x => x.EndVacationDate).HasColumnType("Date")
            .IsRequired();
            modelBuilder.Entity<VacationRequest>().Property(x => x.VacationDuration).IsRequired();

            modelBuilder.ApplyConfiguration(new SeedVacations());
            modelBuilder.ApplyConfiguration(new SeedGender());
            modelBuilder.ApplyConfiguration(new SeedUser());


        }







    }



}