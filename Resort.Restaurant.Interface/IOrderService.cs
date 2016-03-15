using Resort.Restaurant.Interface.DTOs;

namespace Resort.Restaurant.Interface
{
	public interface IOrderService
	{
		OrderOutputDto MakeOrder(OrderInputDto orderInput);
	}
}
