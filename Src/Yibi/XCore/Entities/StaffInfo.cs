using System;

namespace Nebula.Services.Dingtalk.Entities
{
    public class StaffInfo
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 用户ID，对应钉钉的用户ID
        /// </summary>
        public string UserId { get; set; }

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
        public string MobilePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 所属部门ID
        /// </summary>
        public string DepmtIds { get; set; }

        /// <summary>
        /// 所属部门名称
        /// </summary>
        public string DepmtNames { get; set; }

        /// <summary>
        /// 是否是部门的主管
        /// </summary>
        public bool IsLeader { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
