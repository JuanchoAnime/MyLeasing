namespace MyLeasing.Common.Rest
{
    using System.Collections.Generic;

    public class PropertyRest: BaseRest
    {
        public int IdOwner { get; set; }

        public string Neighborhood { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public int SquareMeters { get; set; }

        public int Rooms { get; set; }

        public int Stratum { get; set; }

        public bool HasParkingLot { get; set; }

        public bool IsAvailable { get; set; }

        public string Remarks { get; set; }

        public PropertyTypeRest PropertyType { get; set; }

        public ICollection<PropertyImageRest> PropertiesImages { get; set; }

        public ICollection<ContractRest> Contracts { get; set; }
    }
}
