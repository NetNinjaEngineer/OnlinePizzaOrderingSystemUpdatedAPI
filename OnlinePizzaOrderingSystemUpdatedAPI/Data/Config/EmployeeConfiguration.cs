using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Enums;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
               .HasColumnType("VARCHAR")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(x => x.Position)
                .HasConversion(
                    x => x.ToString(),
                    x => (Position)Enum.Parse(typeof(Position), x)
                );

            builder.HasOne(x => x.Location)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.LocationId)
                .IsRequired();

            builder.ToTable("Employees");
            builder.HasData(GetEmployees());
        }

        private static List<Employee> GetEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "John Smith", PhoneNumber = "555-1234",  Position = Position.Manager, LocationId = 1 },
                new Employee { Id = 3, Name = "Bob Johnson", PhoneNumber = "555-2468", Position = Position.Cook, LocationId = 2 },
                new Employee { Id = 4, Name = "Sue Davis", PhoneNumber = "555-7890",   Position = Position.FoodPrep, LocationId = 3 },
                new Employee { Id = 5, Name = "Mike Brown", PhoneNumber = "555-1357",    Position = Position.DeliveryDriver, LocationId = 4 },
                new Employee { Id = 6, Name = "Mary Williams", PhoneNumber = "555-3690", Position = Position.Cleaner, LocationId = 5 },
            };

            return employees;
        }
    }

}
