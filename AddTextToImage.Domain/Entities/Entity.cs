using System.ComponentModel.DataAnnotations;


namespace AddTextToImage.Domain.Entities
{
    public enum ModelItemType 
    { 
        Text, 
        Clipart 
    }

    ///<summary>
    ///Base class for all entity classes
    ///</summary>
    public abstract class Entity
    {
         [Key]
        public int Id { get; set; }

    }
}
