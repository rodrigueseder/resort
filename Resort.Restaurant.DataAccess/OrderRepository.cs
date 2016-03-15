using AutoMapper;
using Resort.Restaurant.Constraints;
using Resort.Restaurant.DataAccess.DTOs;
using Resort.Restaurant.DataAccess.Models;
using StructureMap;
using System.Collections.Generic;
using System.Linq;

namespace Resort.Restaurant.DataAccess
{
	public class OrderRepository : IOrderRepository
	{
		private IContainer container;

		public OrderRepository(IContainer container)
		{
			this.container = container;
		}

		public List<DishDto> GetDishesBasedOnMenuAndDishTypes(int menuTypeId, List<int> dishTypeIds)
		{
			var menuDishList = getAllMenuDish().Where(md => (int)md.Menu.Type == menuTypeId && dishTypeIds.Contains((int)md.Dish.Type));
			var dishes = menuDishList.Select(md => md.Dish);
			var mapper = container.GetInstance<IMappingEngine>().Mapper;
			return mapper.Map<List<DishDto>>(dishes);
		}

		//TODO: Mock of database, should be removed implementing EF code first
		private List<MenuDish> getAllMenuDish()
		{
			var morningMenu = new Menu { Description = "Morning Menu", Type = MenuType.Morning };
			var eggsDish = new Dish { Description = "eggs", Type = DishType.Entrée };
			var toastDish = new Dish { Description = "Toast", Type = DishType.Side };
			var coffeeDish = new Dish { Description = "coffee", Type = DishType.Drink };

			var nightMenu = new Menu { Description = "Night Menu", Type = MenuType.Night };
			var steakDish = new Dish { Description = "steak", Type = DishType.Entrée };
			var potatoDish = new Dish { Description = "potato", Type = DishType.Side };
			var wineDish = new Dish { Description = "wine", Type = DishType.Drink };
			var cakeDish = new Dish { Description = "cake", Type = DishType.Dessert };

			var menuDishList = new List<MenuDish>
			{
				new MenuDish { Menu = morningMenu, Dish = eggsDish, Default = true, QuantityMax = 1 },
				new MenuDish { Menu = morningMenu, Dish = toastDish, Default = true, QuantityMax = 1 },
				new MenuDish { Menu = morningMenu, Dish = coffeeDish, Default = true, QuantityMax = decimal.MaxValue },

				new MenuDish { Menu = nightMenu, Dish = steakDish, Default = true, QuantityMax = 1 },
				new MenuDish { Menu = nightMenu, Dish = potatoDish, Default = true, QuantityMax = decimal.MaxValue },
				new MenuDish { Menu = nightMenu, Dish = wineDish, Default = true, QuantityMax = 1 },
				new MenuDish { Menu = nightMenu, Dish = cakeDish, Default = true, QuantityMax = 1 },
			};

			return menuDishList;
		}
	}
}
