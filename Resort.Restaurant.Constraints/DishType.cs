using System.ComponentModel;

namespace Resort.Restaurant.Constraints
{
	public enum DishType
	{
		[Description("Appetizer")]
		Appetizer = 0,

		[Description("Entrée")]
		Entrée = 1,

		[Description("Side")]
		Side = 2,

		[Description("Drink")]
		Drink = 3,

		[Description("Dessert")]
		Dessert = 4,
	}
}
