using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.Core.Entities
{
    public class StaffInfo
    {
        /// <summary>
        /// 用户ID，对应钉钉的用户ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string StaffNumber { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>
        public string DepmtId { get; set; }

        /// <summary>
        /// 所属部门名称
        /// </summary>
        public string DepmtName { get; set; }

        /// <summary>
        /// 是否是部门的主管
        /// </summary>
        public bool IsLeader { get; set; }
    }
}
