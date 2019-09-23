using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class ProcessInstanceInfo
    {
        public string Id { get; set; }

        public ProcessInstanceStatus Status { get; set; }

        public string ApprovedResult { get; set; }

        public DateTime LastApprovedDate { get; set; }

        public string CallbackUrl { get; set; }

        public int CallbackTimes { get; set; }

        public bool IsFinish { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }

    public enum ProcessInstanceStatus
    {
        New,
        Running,
        Terminated,
        Completed
    }
}
