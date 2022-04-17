using Drippyz.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Drippyz.Models
{
    //inherit from Ientitybase
    public class Store:IEntityBase
    {  
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company Logo")]
        public string Glyph { get; set; }

        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Display(Name = "About")]
        public string Description { get; set; }

        //Relationship (Store can have a list of products)
        public List<Product> Products { get; set; }

    }
}
