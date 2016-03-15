using Resort.Container;
using Resort.Restaurant.Interface;
using Resort.Restaurant.Interface.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resort.Restaurant.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleAppBootstrap.Setup();
			Console.Write("Input: ");
			var input = Console.ReadLine();
			var orderInput = mapInputToOrder(input);
			var orderOutput = ResortContainer.Container.GetInstance<IOrderService>().MakeOrder(orderInput);
			var output = mapOrderToOutput(orderOutput);
			Console.Write("Output: " + output);
			Console.ReadLine();
		}

		private static OrderInputDto mapInputToOrder(string input)
		{
			var inputs = new List<string>(input.Split(','));
			var menuTypeDescription = inputs[0].Trim();
			inputs.Remove(menuTypeDescription);
			var dishTypeIds = new List<int>();
			foreach (var dishTypeString in inputs)
			{
				int dishTypeId;
				if (int.TryParse(dishTypeString.Trim(), out dishTypeId))
					dishTypeIds.Add(dishTypeId);
			}

			var orderInput = new OrderInputDto { MenuTypeDescription = menuTypeDescription, DishTypeIds = dishTypeIds };
			return orderInput;
		}

		private static string mapOrderToOutput(OrderOutputDto orderOutput)
		{
			var output = "error";
			if (orderOutput != null && orderOutput.DishesNames != null && orderOutput.DishesNames.Count > 0)
			{
				var orderOutputGrouped = orderOutput.DishesNames.GroupBy(d => d).ToList();
				var orderOutputByDish = new List<string>();
				foreach (var group in orderOutputGrouped)
				{
					var count = group.Count();
					var qty = count > 1 ? string.Format("(x{0})", count) : string.Empty;
					var orderOutputDish = string.Format("{0}{1}", group.Key, qty);
					orderOutputByDish.Add(orderOutputDish);
				}
				output = string.Join(", ", orderOutputByDish);
			}
			return output;
		}
	}
}
