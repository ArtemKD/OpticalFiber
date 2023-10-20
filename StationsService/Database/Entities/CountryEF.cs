namespace StationsService.Database.Entities
{
	public class CountryEF
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? YandexCode { get; set; }

		public List<RegionEF> Regions { get; set; } = new();
	}
}
