using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVDCollectRAPI.Data;

[Table("AppSettings")]
public class AppSettingEntity
{
    [Key]
    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}
