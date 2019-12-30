using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class ContactMessageNoticeInfo
    {
        public Guid Id { get; set; }

        public Guid ContactId { get; set; }

        public string DingtalkUserId { get; set; }

        public string Email { get; set; }

        public string MobilePhone { get; set; }

        public string EmailContent { get; set; }

        public string SmsContent { get; set; }

        public string DingtalkContent { get; set; }

        public bool IsSendDingtalk { get; set; }

        public bool IsSendEmail { get; set; }

        public bool IsSendSms { get; set; }

        public bool IsFinish { get; set; }

        public int TotalOperation { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
