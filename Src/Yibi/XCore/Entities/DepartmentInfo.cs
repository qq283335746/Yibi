using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class DepartmentInfo
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long ParentId { get; set; }
    }
}
