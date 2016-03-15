using AutoMapper;
using Resort.Restaurant.Business.DTOs;
using Resort.Restaurant.Constraints;
using Resort.Restaurant.DataAccess;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resort.Restaurant.Business
{
	public class OrderMaintenance : IOrderMaintenance
	{
		private IContainer container;
		private IOrderRepository orderRepository;

		public OrderMaintenance(IContainer container)
		{
			this.container = container;
		}

		public OrderBusinessOutputDto MakeOrder(OrderBusinessInputDto orderBusinessInput)
		{
			OrderBusinessOutputDto orderBusinessOutput = null;
			MenuType menuType;

			if (Enum.TryParse(orderBusinessInput.MenuTypeDescription, true, out menuType))
			{
				orderRepository = container.GetInstance<IOrderRepository>();
				var mapper = container.GetInstance<IMappingEngine>().Mapper;
				orderBusinessOutput = new OrderBusinessOutputDto { Dishes = new List<DishBusinessDto>() };

				var dishes = orderRepository.GetDishesBasedOnMenuAndDishTypes((int)menuType, orderBusinessInput.DishTypeIds);
				var dishBusinessList = mapper.Map<IEnumerable<DishBusinessDto>>(dishes);

				foreach (var dishTypeId in orderBusinessInput.DishTypeIds)
				{
					var dishBusiness = dishBusinessList.FirstOrDefault(d => (int)d.Type == dishTypeId);
					dishBusiness = dishBusiness ?? new DishBusinessDto { Description = "error" };
					orderBusinessOutput.Dishes.Add(dishBusiness);
				}
			}

			return orderBusinessOutput;
		}
	}
}
