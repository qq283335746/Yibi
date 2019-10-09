using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class ContactInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public string StaffNumber { get; set; }

        public string DingtalkUserId { get; set; }

        public string TemplateIds { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
