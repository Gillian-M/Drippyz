using Drippyz.Data;
using Drippyz.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drippyz.Models
{
    public class NewProductVM
    {
        [Display(Description = "Product")]
        [Required(ErrorMessage = "Name is required")]


        public string Name { get; set; }

        [Display(Description = "Product Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Description = "Price €")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Description = "Image Url")]
        [Required(ErrorMessage = "Image Url Is required")]

        public string ImageURL { get; set; }

        [Display(Description = "Product Categroy")]
        [Required(ErrorMessage = "Product Category is required")]

        public ProductCategory ProductCategory { get; set; }
        //Relationship with Store

        [Display(Description = "Store")]
        [Required(ErrorMessage = "Store is required")]
        public int StoreId { get; set; }


    }
}