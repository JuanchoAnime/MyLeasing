namespace MyLeasing.Common.Rest
{
    using System;

    public class ContractRest: BaseRest
    {
        public string Remarks { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime StartDateLocal => StartDate.ToLocalTime();

        public DateTime EndDateLocal => EndDate.ToLocalTime();

        public PropertyRest Property { get; set; }

        public OwnerRest Owner { get; set; }

        public LesseeRest Lessee { get; set; }
    }
}
