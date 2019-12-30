using System;
using System.Collections.Generic;
using System.Text;

namespace Nebula.Services.Dingtalk.Enums
{
    /// <summary>
    /// 智能工作流-审批实例状态枚举值
    /// </summary>
    public enum ProcessInstanceStatus
    {
        /// <summary>
        /// 新创建
        /// </summary>
        New,
        /// <summary>
        /// 运行中
        /// </summary>
        Running,
        /// <summary>
        /// 被终止
        /// </summary>
        Terminated,
        /// <summary>
        /// 完成
        /// </summary>
        Completed
    }
}
