namespace MyLeasing.Common.Rest
{
    using System.Collections.Generic;

    public class OwnerRest: BaseRest
    {
        public UserRest User { get; set; }

        public ICollection<PropertyRest> Properties { get; set; }

        public ICollection<ContractRest> Contracts { get; set; }

        public string Password { get; set; }
    }
}
