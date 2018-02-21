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
        [MaxLength(15, ErrorMessage = "The name is way too long"), MinLength(4, ErrorMessage = "must be at least 5 characters")]
        public string Name { get; set; }

        [Required]
        public DateTime StockDate { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public bool IsTaxable { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Product()
        {
            IsTaxable = false;
        }

        // navigation property, eager loading related detail info
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
    }
}