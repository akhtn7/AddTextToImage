using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddTextToImage.Domain.Entities
{
    public abstract class TemplateBase : Entity
    {
        public int EffectType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Used only for template creation
        [Required]
        [MaxLength(50)]
        public string Text { get; set; }

        public int TextColor1 { get; set; }

        public int TextColor2 { get; set; }

        public bool TextGradientEnable { get; set; }

        public int OutlineColor1 { get; set; }

        public int OutlineThickness1 { get; set; }

        public int OutlineColor2 { get; set; }

        public int OutlineThickness2 { get; set; }

        public bool ShadowEnable { get; set; }

        public int ShadowColor { get; set; }

        public int ShadowThickness { get; set; }

        public int ShadowOffsetX { get; set; }

        public int ShadowOffsetY { get; set; }

        public int FontId { get; set; }

        [ForeignKey("FontId")]
        public virtual FontInfo Font { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] Image { get; set; }
    }
}
