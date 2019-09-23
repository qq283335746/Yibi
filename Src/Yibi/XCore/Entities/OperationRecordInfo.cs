using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class OperationRecordInfo
    {
        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public string OperationType { get; set; }

        public string OperationResult { get; set; }

        public string Remark { get; set; }
    }
}
