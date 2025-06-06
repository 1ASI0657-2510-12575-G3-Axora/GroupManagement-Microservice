namespace DittoBox.API.GroupManagement.Domain.Models.Entities
{
    public class Location(
        string country,
        string city,
        string state,
        string? address = null
    )
    {
        public int Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? PlusCode { get; set; }
        public string Country { get; set; } = country;
        public string State { get; set; } = state;
        public string City { get; set; } = city;
        public string? Address { get; set; } = address;

        public void UpdateLatitudeAndLongitude(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Location FromLocation(Location location)
        {
            return new Location(location.Country, location.City, location.State, location.Address)
            {
                Id = location.Id,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                PlusCode = location.PlusCode
            };
        }   
        
    }
}