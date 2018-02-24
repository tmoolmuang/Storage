using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Product name is too long"), MinLength(5, ErrorMessage = "Product name must be at least 5 characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StockDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExpiredDate { get; set; }

        public bool IsTaxable { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        // constructor to set default value
        public Product()
        {
            IsTaxable = false;
        }

        // navigation property, eager loading related product type name
        public ProductType ProductType { get; set; }
    }
}