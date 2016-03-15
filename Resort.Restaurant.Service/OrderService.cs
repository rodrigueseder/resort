using AutoMapper;
using Resort.Restaurant.Business;
using Resort.Restaurant.Business.DTOs;
using Resort.Restaurant.Interface;
using Resort.Restaurant.Interface.DTOs;
using StructureMap;

namespace Resort.Restaurant.Service
{
	public class OrderService : IOrderService
	{
		private IContainer container;

		public OrderService(IContainer container)
		{
			this.container = container;
		}

		public OrderOutputDto MakeOrder(OrderInputDto orderInput)
		{
			var mapper = container.GetInstance<IMappingEngine>().Mapper;
			var orderBo = container.GetInstance<OrderBO>();

			var orderBusinessInput = mapper.Map<OrderBusinessInputDto>(orderInput);
			var orderBusinessOutput = orderBo.MakeOrder(orderBusinessInput);
			var orderOutput = mapper.Map<OrderOutputDto>(orderBusinessOutput);

			return orderOutput;
		}
	}
}
