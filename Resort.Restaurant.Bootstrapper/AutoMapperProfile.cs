using AutoMapper;
using Resort.Restaurant.Business.DTOs;
using Resort.Restaurant.DataAccess.DTOs;
using Resort.Restaurant.DataAccess.Models;
using Resort.Restaurant.Interface.DTOs;

namespace Resort.Restaurant.Bootstrapper
{
	public class AutoMapperProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Dish, DishDto>().ReverseMap();
			CreateMap<DishDto, DishBusinessDto>().ReverseMap();
			CreateMap<OrderInputDto, OrderBusinessInputDto>();
			CreateMap<OrderBusinessOutputDto, OrderOutputDto>()
				.ForMember(d => d.DishesNames, o => o.MapFrom(s => s.Dishes));
			CreateMap<DishBusinessDto, string>().ConvertUsing(source => source.Description);
		}
	}
}
