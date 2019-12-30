using System;
using System.Collections.Generic;
using System.Text;

namespace Nebula.Services.Dingtalk.Entities
{
    public class DepartmentInfo
    {
        public Guid Id { get; set; }

        public long DepmtId { get; set; }

        public string Name { get; set; }

        public long ParentId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
