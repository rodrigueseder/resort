using Resort.Restaurant.DataAccess.DTOs;
using System.Collections.Generic;

namespace Resort.Restaurant.DataAccess
{
	public interface IOrderRepository
	{
		List<DishDto> GetDishesBasedOnMenuAndDishTypes(int menuTypeId, List<int> dishTypeIds);
	}
}
