﻿namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Lessee")]
    public class LesseeDto: BaseEntity
    {
        public UserDto User { get; set; }

        public ICollection<ContractDto> Contracts { get; set; }
    }
}
