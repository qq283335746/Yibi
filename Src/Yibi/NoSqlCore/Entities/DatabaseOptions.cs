using System.ComponentModel.DataAnnotations;
using Yibi.NoSqlCore.Enums;

namespace Yibi.NoSqlCore.Entities
{
    public class DatabaseOptions
    {
        public DatabaseType Type { get; set; }

        [Required]
        public string ConnectionString { get; set; }
    }
}
