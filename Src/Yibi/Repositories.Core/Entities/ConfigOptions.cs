using System.ComponentModel.DataAnnotations;

namespace Yibi.Repositories.Core.Entities
{
    public class ConfigOptions
    {
        public bool RunMigrationsAtStartup { get; set; } = true;

        [Required]
        public DatabaseOptions Database { get; set; }

        public string PathBase { get; set; }
    }
}
