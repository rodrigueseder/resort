using System.ComponentModel;

namespace Resort.Restaurant.Constraints
{
	public enum MenuType
	{
		[Description("Morning")]
		Morning = 1,

		[Description("Noon")]
		Noon = 2,

		[Description("Night")]
		Night = 3,
	}
}
