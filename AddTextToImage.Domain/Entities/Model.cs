using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddTextToImage.Domain.Entities
{
    public class Model : Entity
    {
        [Required]
        [MaxLength(10)]
        public string ContentType { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] Image { get; set; }

        public int ImageWidth { get; set; }

        public int ImageHeight { get; set; }

        public virtual ICollection<ModelItem> Items { get; set; }

        public Model()
        {
            Items = new HashSet<ModelItem>();
        }

    }
}
