using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Configs
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");
            builder.HasKey(empl => empl.Id);
            builder.Property(x => x.Id).HasColumnName("employee_id");
            builder.Property(x => x.FirstName).HasColumnName("first_name");
            builder.Property(x => x.LastName).HasColumnName("last_name");
            builder.Property(x => x.Patronymic).HasColumnName("patronymic");
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number");
            builder.Property(x => x.Position).HasColumnName("position");
            builder.Property(x => x.Salary).HasColumnName("salary");
            builder.Property(x => x.Address).HasColumnName("address");
            builder.Property(x => x.BirthDate).HasColumnName("birth_date");
            builder.Property(x => x.RecruitDate).HasColumnName("recruit_date");
            builder.Property(x => x.QuitDate).HasColumnName("quit_date");
            builder.Property(x => x.Status).HasColumnName("status");
        }
    }
}
