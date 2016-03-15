using System.Collections.Generic;

namespace Resort.Restaurant.Interface.DTOs
{
	public class OrderInputDto
	{
		public List<int> DishTypeIds { get; set; }
		public string MenuTypeDescription { get; set; }
	}
}
