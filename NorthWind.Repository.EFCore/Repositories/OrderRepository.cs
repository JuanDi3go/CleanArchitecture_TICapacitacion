using NorthWay.Entities.Interfaces;
using NorthWay.Entities.PocoEntities;
using NorthWay.Entities.Specifications;
using NorthWind.Repository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly NorthWindContext _context;

        public OrderRepository(NorthWindContext context)
        {
            _context = context;
        }

        public void Create(Order order)
        {
            _context.Add(order);
        }

        public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
        {
           var ExpressionDelegate = specification.Expression.Compile();
            return _context.Orders.Where(ExpressionDelegate);
        }
    }
}
