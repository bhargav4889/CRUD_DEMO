using System.ComponentModel.DataAnnotations;

namespace CRUD_ALL.Models
{
    public class Product_Model
    {
        
        public int Product_ID { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        public string Product_Name { get; set;}

        [Required(ErrorMessage = "Please Enter Product Price")]
        public decimal Product_Price { get; set;}

        [Required(ErrorMessage = "Please Enter Product SKU")]
        public string Product_SKU { get; set;}

        [Required(ErrorMessage = "Please Upload Product Image")]
        public IFormFile? Product_Image {  get; set;}
        
        public string? Product_Image_Path{ get; set;}

        [Required(ErrorMessage = "Please Select Product Status")]
        public bool Is_Product_Active { get; set;}

    }
}
