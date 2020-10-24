namespace MyLeasing.Common.Rest
{
    using System.Collections.Generic;

    public class LesseeRest: BaseRest
    {
        public UserRest User { get; set; }

        public ICollection<ContractRest> Contracts { get; set; }
    }
}
