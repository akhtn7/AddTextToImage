using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;


namespace AddTextToImage.Domain.Entities
{
    public class ClipartTemplate : TemplateBase
    {
        public int ClipartGalleryId { get; set; }

        [ForeignKey("ClipartGalleryId")]
        [JsonIgnore]
        public virtual ClipartGallery ClipartGallery { get; set; }
    }
}
