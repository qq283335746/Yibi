using System;
using System.ComponentModel.DataAnnotations;
using Yibi.Core.Enums;

namespace Yibi.Core.Entities
{
    public class DatabaseOptions
    {
        public DatabaseType Type { get; set; }

        [Required]
        public string ConnectionString { get; set; }
    }
}
