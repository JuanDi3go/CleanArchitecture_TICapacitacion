using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCasesDTOs.CreateOrder
{
    public class CreateOrderParams
    {
        public string CostumerId { get; set; }
        public string ShipAdress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public List<CreateOrderDetailParams> OrderDetails { get; set; }
    }
}
