using System;
using System.ComponentModel.DataAnnotations;
using Yibi.Repositories.Core.Enums;

namespace Yibi.Repositories.Core.Entities
{
    public class DatabaseOptions
    {
        public DatabaseType Type { get; set; }

        [Required]
        public string ConnectionString { get; set; }
    }
}
