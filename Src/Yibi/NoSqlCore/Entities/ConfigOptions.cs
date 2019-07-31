using System.ComponentModel.DataAnnotations;

namespace Yibi.NoSqlCore.Entities
{
    public class ConfigOptions
    {
        [Required]
        public DatabaseOptions NoSqlDatabase { get; set; }
    }
}
