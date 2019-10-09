using System;
using System.Collections.Generic;
using System.Text;

namespace Yibi.MessageCenter
{
    public class EmailSettingInfo
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Password { get; set; }
    }
}
