using Resort.Restaurant.Business.DTOs;

namespace Resort.Restaurant.Business
{
	public interface IOrderMaintenance
	{
		OrderBusinessOutputDto MakeOrder(OrderBusinessInputDto orderBusinessInput);
	}
}
