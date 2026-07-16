using System.ComponentModel.DataAnnotations.Schema;

namespace DVDCollectRAPI.Data;

[Table("Genres")]
public class GenreEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<DvdEntity> DVDs { get; set; } = [];
}
