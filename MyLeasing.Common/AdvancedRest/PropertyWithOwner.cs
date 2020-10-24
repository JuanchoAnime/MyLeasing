namespace MyLeasing.Common.AdvancedRest
{
    using MyLeasing.Common.Rest;

    public class PropertyWithOwner: PropertyRest
    {
        public OwnerRest Owner { get; set; }
    }
}
