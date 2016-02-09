using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddTextToImage.Domain.Entities
{
    public class TextTemplate : TemplateBase
    {
        public int TextGalleryId { get; set; }

        [ForeignKey("TextGalleryId")]
        [JsonIgnore]
        public virtual TextGallery TextGallery { get; set; }
    }
}
