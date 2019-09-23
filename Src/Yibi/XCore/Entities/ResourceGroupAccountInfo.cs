using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class ResourceGroupAccountInfo
    {
        public Guid Id { get; set; }

        public string Environment { get; set; }

        public string TypeName { get; set; }

        public string EntryPoint { get; set; }

        public string AccountPassword { get; set; }

        public string AllowUsers { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
