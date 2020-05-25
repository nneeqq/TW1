using eProject.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eProject.Web.Models
{
    public class UserData
    {
        public string Username { get; set; }

        [Display(Name = "Product name")]
        [StringLength(50, ErrorMessage = "Product name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Display(Name = "Product description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Image URL")]
        public string imageURL { get; set; }

        public URole Level { get; set; }

        [Display(Name = "Product name")]
        [StringLength(50, ErrorMessage = "Product name cannot be longer than 50 characters.")]
        public List<string> NameList { get; set; }

        [Display(Name = "Product description")]
        public List<string> DescriptionList { get; set; }

        [Display(Name = "Price")]
        public List<decimal> PriceList { get; set; }

        [Display(Name = "Image URL")]
        public List<string> imageList { get; set; }
    }
}