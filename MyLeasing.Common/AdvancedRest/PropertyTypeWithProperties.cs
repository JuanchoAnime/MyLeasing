namespace MyLeasing.Common.AdvancedRest
{
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;

    public class PropertyTypeWithProperties: PropertyTypeRest
    {
        public ICollection<PropertyRest> Properties { get; set; }
    }
}
