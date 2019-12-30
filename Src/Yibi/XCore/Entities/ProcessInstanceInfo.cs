using System;
using Nebula.Services.Dingtalk.Enums;

namespace Nebula.Services.Dingtalk.Entities
{
    public class ProcessInstanceInfo
    {
        public Guid Id { get; set; }

        public string ProcessInstanceId { get; set; }

        public ProcessInstanceStatus Status { get; set; }

        public string ApprovedResult { get; set; }

        public DateTime LastApprovedDate { get; set; }

        public string CallbackUrl { get; set; }

        public int CallbackTimes { get; set; }

        public bool IsFinish { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
