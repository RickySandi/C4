using AutoMapper;
using C4_Model.Data.Entities;
using C4_Model.Data.Repository;
using C4_Model.Exceptions;
using C4_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C4_Model.Services
{
    public class OrderService
    {
        public class OrdersService : IOrdersService
        {
            private ILibraryRepository _libraryRepository;
            private IMapper _mapper;
        }
        public OrdersService(ILibraryRepository libraryRepository, IMapper _mapper)
        {
            this._libraryRepository = libraryRepository;
            this._mapper = _mapper;
        }

        public IEnumerable<OrderModel> GetOrders()
        {
            var entityList = _libraryRepository.GetOrders();
            var modelList = _mapper.Map<IEnumerable<OrderModel>>(entityList);
            return modelList;
        }
        public OrderModel GetTicket(int OrderId)
        {
            var Ticket = _libraryRepository.GetOrder(OrderId);

            if (Ticket == null)
            {
                throw new NotFoundException($"The Ticket {OrderId} doesnt exists, try it with a new id");
            }

            return _mapper.Map<OrderModel>(Order);
        }

        public OrderModel CreateOrder(OrderModel OrderModel)
        {

            var entityreturned = _libraryRepository.CreateTicket(_mapper.Map<OrderEntity>(OrderModel));

            return _mapper.Map<OrderModel>(entityreturned);
        }

        public bool DeleteOrder(int OrderId)
        {
            var OrderToDelete = GetOrder(OrderId);
            return _libraryRepository.DeleteOrder(OrderId);
        }

        public OrderModel UpdateTicket(int OrderId, OrderModel OrderModel)
        {

            var OrderToUpdate = _libraryRepository.UpdateTicket(_mapper.Map<OrderEntity>(OrderModel));

            return _mapper.Map<OrderModel>(OrderToUpdate);
        }
    }
}

