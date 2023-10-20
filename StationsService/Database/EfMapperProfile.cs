using AutoMapper;
using Domain.Entities;
using Domain.Models;
using NetTopologySuite.Geometries;
using StationsService.Database.Entities;

namespace StationsService.Database
{
	public class EfMapperProfile : Profile
	{
		public EfMapperProfile()
		{
			CreateMap<StationEF, Station>()
				.ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.X))
				.ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Y));

			CreateMap<StationEF, StationPoint>()
				.ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.X))
				.ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Y));

			CreateMap<Station, StationEF>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
				.ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Point(src.Longitude, src.Latitude)));
		}
	}
}
