using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    internal class AppDbContextDesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optsBuilder.UseSqlite("Data Source=C:\\ProgramData\\EmployeesManagement\\data.db");

            return new AppDbContext(optsBuilder.Options);
        }
    }
}
