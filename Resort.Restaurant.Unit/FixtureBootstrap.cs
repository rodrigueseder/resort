using Resort.Restaurant.Bootstrapper;

namespace Resort.Restaurant.Unit
{
	public class FixtureBootstrap
	{
		public static void Setup()
		{
			RestaurantModuleBootstrap.Setup();
		}
	}
}
