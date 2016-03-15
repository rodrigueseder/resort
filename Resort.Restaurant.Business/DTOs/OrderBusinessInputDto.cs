using System.Collections.Generic;

namespace Resort.Restaurant.Business.DTOs
{
	public class OrderBusinessInputDto
	{
		public List<int> DishTypeIds { get; set; }
		public string MenuTypeDescription { get; set; }

	}
}
