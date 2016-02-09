using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddTextToImage.Domain.Entities
{
    public class ClipartGallery : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ClipartTemplate> Items { get; set; }

        public  ClipartGallery()
        {
            Items = new HashSet<ClipartTemplate>();
        }
    }
}
