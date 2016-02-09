using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AddTextToImage.Domain.Entities
{
    public class Sample : Entity
    {
        [Required]
        [MaxLength(10)]
        public string ContentType { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] Image { get; set; }

        public int ImageWidth { get; set; }

        public int ImageHeight { get; set; }

        [Required]
        [JsonIgnore]
        public byte[] Thumbnail { get; set; }

        public virtual ICollection<SampleItem> Items { get; set; }

        public Sample()
        {
            Items = new HashSet<SampleItem>();
        }
    }
}
