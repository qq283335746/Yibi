using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class MessageTemplateInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string Parms { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
