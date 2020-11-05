﻿namespace MyLeasing.Common.Response
{
    using System.Collections.Generic;

    public class OwnerResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ICollection<PropertyResponse> Properties { get; set; }
    }
}
