using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class TypeNameInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
