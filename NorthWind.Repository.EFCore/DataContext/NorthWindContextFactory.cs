using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.DataContext
{
    class NorthWindContextFactory : IDesignTimeDbContextFactory<NorthWindContext>
    {
        public NorthWindContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<NorthWindContext>();

            optionBuilder.UseSqlServer("Server=(local); database=NorthWindDb;User Id=sa;Password=nexos; Trust Server Certificate=True;");

            return new NorthWindContext(optionBuilder.Options);
        }
    }
}
