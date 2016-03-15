using AutoMapper;
using Resort.Container;
using Resort.Restaurant.Business;
using Resort.Restaurant.DataAccess;
using Resort.Restaurant.Interface;
using Resort.Restaurant.Service;
using StructureMap.Graph;

namespace Resort.Restaurant.Bootstrapper
{
	public class RestaurantModuleBootstrap
	{
		public static void Setup()
		{
			ResortContainer.Container = new StructureMap.Container();

			ResortContainer.Container.Configure(config =>
			{
				config.Scan(scan =>
				{
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
				});

				config.For<IOrderService>().Use<OrderService>();
				config.For<IOrderMaintenance>().Use<OrderMaintenance>();
				config.For<IOrderRepository>().Use<OrderRepository>();
				Mapper.AddProfile(new AutoMapperProfile());
				config.For<IMappingEngine>().Use(() => Mapper.Engine);
			});
		}

	}
}