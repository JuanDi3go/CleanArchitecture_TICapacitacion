using MediatR;
using NorthWay.Entities.Enums;
using NorthWay.Entities.Exceptions;
using NorthWay.Entities.Interfaces;
using NorthWay.Entities.PocoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    //implementa el caso de uso
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository _orderRepository;
        readonly IOrderDetailRepository _orderDetailRepository;
        readonly IUnitOfWork _unitOfWork;
        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateOrderInputPort request, CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                CustomerId = request.CostumerId,
                OrderDate = DateTime.Now,
                ShipAdress = request.ShipAdress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPostalCode,
                ShippingType = ShippingType.Road,
                DiscountType = DiscountType.Percentage,
                Discount = 10
            };

            _orderRepository.Create(order);

            foreach (var item in request.OrderDetails)
            {
                _orderDetailRepository.Create(new OrderDetail
                {
                    Order = order,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                });
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new GeneralException("Error al crear la orden.", ex.Message);
            }
            return order.Id;

        }
    }
}
