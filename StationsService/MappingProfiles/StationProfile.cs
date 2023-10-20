using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace StationsService.MappingProfiles
{
	public class StationProfile : Profile
	{
		public StationProfile()
		{
			CreateMap<Station, StationPoint>();
		}
	}
}
