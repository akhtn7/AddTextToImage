using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddTextToImage.Domain.Entities
{

    public class FontInfo : Entity
    {
        [Required]
        [MaxLength(50)]
        [Index("IX_FontInfo_Name", IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Index("IX_FontInfo_FileName", IsUnique = true)]
        public string FileName { get; set; }

        // Used only for template creation
        public bool IsClipart { get; set; }
    }
}
