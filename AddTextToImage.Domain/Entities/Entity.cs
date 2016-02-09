using System.ComponentModel.DataAnnotations;


namespace AddTextToImage.Domain.Entities
{
    //XXXX
    public enum ModelItemType { Text, Clipart }

    public abstract class Entity
    {
        //[JsonProperty(PropertyName = "ModelId")]
         [Key]
        public int Id { get; set; }

    }
}
