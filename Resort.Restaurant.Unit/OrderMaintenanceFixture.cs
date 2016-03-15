using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Resort.Container;
using Resort.Restaurant.Business;
using Resort.Restaurant.Business.DTOs;
using Resort.Restaurant.Constraints;
using Resort.Restaurant.DataAccess;
using Resort.Restaurant.DataAccess.DTOs;
using StructureMap;
using System.Collections.Generic;

namespace Resort.Restaurant.Unit
{
	[TestClass]
	public class OrderMaintenanceFixture
	{
		private IContainer container;

		[TestInitialize()]
		public void Initialize()
		{
			FixtureBootstrap.Setup();
			container = ResortContainer.Container.GetNestedContainer();

			var eggsDish = new DishDto { Description = "eggs", Type = DishType.Entrée };
			var toastDish = new DishDto { Description = "Toast", Type = DishType.Side };
			var coffeeDish = new DishDto { Description = "coffee", Type = DishType.Drink };
			var menuDishList = new List<DishDto> { eggsDish, toastDish, coffeeDish };

			var orderRepositoryMock = new Mock<IOrderRepository>();
			orderRepositoryMock.Setup(x => x.GetDishesBasedOnMenuAndDishTypes(It.IsAny<int>(), It.IsAny<List<int>>())).Returns(menuDishList);
		}

		[TestMethod]
		public void _01_should_make_order()
		{
			var orderBusinessInput = new OrderBusinessInputDto { MenuTypeDescription = "Morning", DishTypeIds = new List<int> { 1, 2, 3, 3, 3, 4 } };
			var orderMaintenance = container.GetInstance<IOrderMaintenance>();
			var orderBusinessOutput = orderMaintenance.MakeOrder(orderBusinessInput);

			Assert.IsNotNull(orderBusinessOutput);
			Assert.IsNotNull(orderBusinessOutput.Dishes);
			Assert.AreEqual(6, orderBusinessOutput.Dishes.Count);

			var dish = orderBusinessOutput.Dishes[0];
			Assert.AreEqual("eggs", dish.Description);

			dish = orderBusinessOutput.Dishes[1];
			Assert.AreEqual("Toast", dish.Description);

			dish = orderBusinessOutput.Dishes[2];
			Assert.AreEqual("coffee", dish.Description);

			dish = orderBusinessOutput.Dishes[3];
			Assert.AreEqual("coffee", dish.Description);

			dish = orderBusinessOutput.Dishes[4];
			Assert.AreEqual("coffee", dish.Description);

			dish = orderBusinessOutput.Dishes[5];
			Assert.AreEqual("error", dish.Description);
		}
	}
}
