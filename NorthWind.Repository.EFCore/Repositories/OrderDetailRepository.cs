using NorthWay.Entities.Interfaces;
using NorthWay.Entities.PocoEntities;
using NorthWind.Repository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private NorthWindContext _context;
        
        public OrderDetailRepository(NorthWindContext context)
        {
            _context = context;
        }

        public void Create(OrderDetail orderDetail)
        {
            _context.Add(orderDetail);
        }
    }
}
