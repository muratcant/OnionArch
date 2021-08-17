using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
