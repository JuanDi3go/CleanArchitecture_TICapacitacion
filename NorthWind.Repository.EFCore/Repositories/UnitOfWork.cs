using NorthWay.Entities.Interfaces;
using NorthWind.Repository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private NorthWindContext _context;

        public UnitOfWork(NorthWindContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
                return _context.SaveChangesAsync();
        }
    }
}
