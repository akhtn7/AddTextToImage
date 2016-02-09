using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddTextToImage.Domain.Entities
{
    public class ModelItem : Entity
    {
        public ModelItemType ItemType { get; set; }

        public int PositionTop { get; set; }

        public int PositionLeft { get; set; }

        [Required]
        [MaxLength(50)]
        public string Text { get; set; }

        public int TemplateId { get; set; }

        public int FontSize { get; set; }

        [Required]
        [MaxLength(7)]
        public string FontColor { get; set; }

        public int Rotation { get; set; }

        public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        [JsonIgnore] 
        public virtual Model Model { get; set; }
    }
}
