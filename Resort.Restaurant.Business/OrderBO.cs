using Resort.Restaurant.Business.DTOs;
using StructureMap;

namespace Resort.Restaurant.Business
{
	public class OrderBO
	{
		private IContainer container;
		private IOrderMaintenance orderMaintenance;

		public OrderBO(IContainer container)
		{
			this.container = container;
		}

		protected IOrderMaintenance OrderMaintenance
		{
			get { return orderMaintenance ?? (orderMaintenance = container.GetInstance<IOrderMaintenance>()); }
		}

		public OrderBusinessOutputDto MakeOrder(OrderBusinessInputDto orderBusinessInput)
		{
			var orderBusinessOutput = OrderMaintenance.MakeOrder(orderBusinessInput);
			return orderBusinessOutput;
		}
	}
}
