using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTextToImage.Domain.Entities
{
    public class TextGallery : Entity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<TextTemplate> Items { get; set; }

        public TextGallery()
        {
            Items = new HashSet<TextTemplate>();
        }
    }
}
